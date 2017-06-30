/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/5/12
 * 时间: 20:56
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
//using System.IO;

namespace xDevice.Common
{
	/// <summary>
	/// Description of MsgLogger.
	/// </summary>
	public class MsgLogger
	{
		//消息队列
		static Queue<LogMsg> MsgQueue = new Queue<LogMsg>();
		static object obj = new object();
		static bool OnOff = false;
		static bool HexMode = true;
		
		public MsgLogger()
		{
			
		}
		
		~MsgLogger()
		{
			MsgQueue.Clear();
		}
		
		/// <summary>
		/// 清除消息队列
		/// </summary>
		public static void Clear()
		{
			lock(obj)
			{
				MsgQueue.Clear();
			}
		}
		
		/// <summary>
		/// 添加消息到队列
		/// </summary>
		/// <param name="msg">消息</param>
		public static void PushMsg(LogMsg msg)
		{
			lock(obj)
			{
				if(OnOff && (MsgQueue.Count < 1024))
					MsgQueue.Enqueue(msg);
			}
		}
		
		/// <summary>
		/// 添加消息到队列
		/// </summary>
		/// <param name="device">消息-设备</param>
		/// <param name="action">消息-动作</param>
		/// <param name="data">消息-数据</param>
		public static void PushMsg(string device, string action, string data)
		{
			lock(obj)
			{
				if(OnOff && (MsgQueue.Count < 1024))
					MsgQueue.Enqueue(new LogMsg(device, action, data));
			}
		}
		
		/// <summary>
		/// 添加消息到队列
		/// </summary>
		/// <param name="device">消息-设备</param>
		/// <param name="action">消息-动作</param>
		/// <param name="data">消息-数据</param>
		public static void PushMsg(string device, string action, byte[] data)
		{
			lock(obj)
			{
				if(!OnOff || (MsgQueue.Count >= 1024))
					return;
				if(HexMode)
				{
					MsgQueue.Enqueue(new LogMsg(device, action, HexString.Bytes2HexString(data)));
				}
				else
				{
					MsgQueue.Enqueue(new LogMsg(device, action, HexString.Bytes2AsciiString(data)));
				}
			}
		}
		
		/// <summary>
		/// 从消息队列中取出一条消息
		/// </summary>
		/// <returns>消息</returns>
		public static LogMsg PullMsg()
		{
			lock(obj)
			{
				return MsgQueue.Dequeue();
			}
		}
		
		/// <summary>
		/// 获取消息队列中的消息数量
		/// </summary>
		/// <returns>消息数量</returns>
		public static int GetMsgNum()
		{
			lock(obj)
			{
				return MsgQueue.Count;
			}
		}
		
		/// <summary>
		/// 设置日志开关
		/// </summary>
		/// <param name="OnorOff">true: 打开； false: 关闭</param>
		public static void SetLogOnOff(bool OnorOff)
		{
			lock(obj)
			{
				OnOff = OnorOff;
			}
		}
		
		/// <summary>
		/// 设置日志是否为16进制模式
		/// </summary>
		/// <param name="OnorOff">true: 打开； false: 关闭</param>
		public static void SetHexMode(bool OnorOff)
		{
			lock(obj)
			{
				HexMode = OnorOff;
			}
		}
		
		
		/// <summary>
		/// 日志是否打开
		/// </summary>
		/// <returns>打开与否</returns>
		public static bool IsLogOn()
		{
			lock(obj)
			{
				return OnOff;
			}
		}
		
		/// <summary>
		/// 日志是否16进制模式记录
		/// </summary>
		/// <returns>打开与否</returns>
		public static bool IsHexMode()
		{
			lock(obj)
			{
				return HexMode;
			}
		}
		
		/// <summary>
		/// 保存日志记录到文件
		/// </summary>
		/// <param name="filepath">文件路径</param>
//		private static void SavetoFile(string filepath)
//		{
//			lock(obj)
//			{
//				using(FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
//				{
//					using(StreamWriter sw = new StreamWriter(fs))
//					{
//						foreach(var item in MsgQueue)
//						{
//							sw.WriteLine(item.Time +"\t"+ item.Device +"\t"+ item.Action +"\t"+ item.Data);
//							sw.Flush();
//						}
//					}
//				}
//			}
//		}
	}
}
