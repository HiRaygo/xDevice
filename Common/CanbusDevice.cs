/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/6/20
 * 时间: 21:32
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Xml;

namespace xDevice.Common
{
	//在线加载状态
	public enum FileLoadState
	{
		Ready = 0,
		Started,
		Loading,
		Loaded,
		Finish,
		Error
	}
	
	/// <summary>
	/// Description of ModbusDevice.
	/// </summary>
	public class CanbusDevice
	{
		public string Name;
		public byte Address;
		public bool Running;
				
		bool mToRun;
		int mLastTime;
		object obj = new object();
		//文件加载、上传状态
		FileLoadState mFLState;
		int mFrameId, mFrameLen;
		
		public CanbusDevice(string name, byte addr)
		{
			Name = name;
			Address = addr;
			mToRun = false;
		}
		
	
		/// <summary>
		/// 启动设备
		/// </summary>
		/// <returns></returns>
		public bool Start()
		{
			mToRun = true;
			Running = true;			
			mLastTime	= DateTime.Now.Second;
			MsgLogger.PushMsg(Name, "Start", "Success.");			
			return true;
		}
		
		/// <summary>
		/// 停止设备
		/// </summary>
		/// <returns></returns>
		public bool Stop()
		{
			mToRun = false;		
			Running = false;	
			MsgLogger.PushMsg(Name, "Stop", "Success.");			
			return true;
		}
		
		
		/// <summary>
		/// 解析RTU消息
		/// </summary>
		/// <param name="recvBytes"></param>
		/// <param name="respBytes"></param>
		/// <returns></returns>
		public bool ParseCanMessage(byte[] rcvBytes, out byte[] rspBytes)
		{	
			rspBytes = null;
			if(!Running)
			{				
				return false;
			}
			if(rcvBytes[1] == 0x41)
			{
				if((rcvBytes[2] > 0) &&(rcvBytes[2] <5))
					return FileDownload(rcvBytes, out rspBytes);
				else
					return false;					
			}
			else
			{
				return false;
			}
		}		

		/// <summary>
		/// 文件加载
		/// </summary>
		/// <param name="rcvBytes"></param>
		/// <param name="rspBytes"></param>
		/// <returns></returns>
		private bool FileDownload(byte[] rcvBytes, out byte[] rspBytes)
		{
			rspBytes = null;
			byte childcode = rcvBytes[2];
			byte datalen = rcvBytes[3];
			byte filetype = rcvBytes[4];
			//判断长度
			if(rcvBytes.Length != datalen+6)
				return false;
			//启动加载
			if(childcode == 0x01)
			{				
				return true;
			}					
			return false;
		}
		
	}
}
