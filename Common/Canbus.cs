/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/6/20
 * 时间: 21:32
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace xDevice.Common
{
	public enum CanbusType
	{
		RectOne = 0,
		RectTwo,
		HWAll
	}
		
	/// <summary>
	/// Description of CanbusDevice.
	/// </summary>
	public class Canbus
	{
		public string Name;			
		public string CommParas;
		public CanbusType CBType;		
		public bool Running;
		
		Dictionary<byte, CanbusDevice> DeviceDict;
		Dictionary<byte, string> DeviceNameDict;
		bool mToRun;
		int mRespDelay;
		//串口参数
		string mComPort;
		int mComTimeout;
		SerialPort mSerialPort;
		
		public Canbus(string name, string commparas)
		{
			Name = name;
			CommParas = commparas;
			mToRun = false;
			Running = false;
			DeviceDict = new Dictionary<byte, CanbusDevice>();
			DeviceNameDict = new Dictionary<byte, string>();
			ParseParas();			
		}
		
		~Canbus()
		{
			Stop();
		}
		
		/// <summary>
		/// 增加设备
		/// </summary>
		/// <param name="device"></param>
		/// <returns></returns>
		public bool AddDevice(CanbusDevice device)
		{			
			if((DeviceDict.ContainsKey(device.Address)) || (DeviceNameDict.ContainsValue(device.Name)))
			{
				MsgLogger.PushMsg(device.Name, "Add", "Fail, already exist.");
				return false;
			}
			else			
			{
				DeviceDict.Add(device.Address, device);
				DeviceNameDict.Add(device.Address, device.Name);
				MsgLogger.PushMsg(device.Name, "Add", "Success.");
				return true;
			}
		}
		
		/// <summary>
		/// 删除设备
		/// </summary>
		/// <param name="device"></param>
		/// <returns></returns>
		public bool DeleteDevice(string devicename)
		{			
			foreach(CanbusDevice device in DeviceDict.Values)
			{
				if(device.Name == devicename)
				{
					//停止设备
					device.Stop();
					//删除
					DeviceDict.Remove(device.Address);
					DeviceNameDict.Remove(device.Address);
					MsgLogger.PushMsg(devicename, "Delete", "Success.");
					return true;
				}
			}
			MsgLogger.PushMsg(devicename, "Delete", "Fail, not exist.");
			return false;
		}
		
		/// <summary>
		/// 根据设备名获取设备
		/// </summary>
		/// <param name="devicename">设备名称</param>
		/// <param name="device">设备</param>
		/// <returns></returns>
		public bool GetDeviceByName(string devicename, out CanbusDevice device)
		{
			foreach(CanbusDevice dv in DeviceDict.Values)
			{
				if(dv.Name == devicename)
				{
					device = dv;
					return true;
				}
			}
			device = null;
			return false;
		}
		
		/// <summary>
		/// 获取设备信息列表
		/// </summary>
		/// <returns>设备名、设备参数列表</returns>
		public string[][] GetDeviceInfo()
		{
			int i = 0;
			string[][] info = new string[2][];
			info[0] = new string[(DeviceDict.Count)];
			info[1] = new string[(DeviceDict.Count)];
			foreach(CanbusDevice device in DeviceDict.Values)
			{
				info[0][i] = device.Name;
				info[1][i] = device.Address.ToString();
				i++;
			}
			return info;
		}
		/// <summary>
		/// 解析通讯参数
		/// </summary>
		/// <returns></returns>
		private bool ParseParas()
		{
			if(CommParas.StartsWith("COM"))
			{
				string[] paras = CommParas.Split(new char[]{','});
				if((paras != null) && (paras.Length == 4))
				{
					mComPort = paras[0];
					mComTimeout = int.Parse(paras[1]);
					mRespDelay = int.Parse(paras[2]);
					if(paras[3] == "0")
						CBType = CanbusType.RectOne;
					else if(paras[3] == "1")
						CBType = CanbusType.RectTwo;
					else
						return false;
				}
				else
					return false;
			}
			return true;
		}
		
		/// <summary>
		/// 启动总线
		/// </summary>
		/// <returns></returns>
		public bool Start()
		{
			mToRun = true;
			if((mSerialPort == null) || (!mSerialPort.IsOpen))
			{
				try{
					mSerialPort = new SerialPort(mComPort+"A", 9600, Parity.None, 8, StopBits.One);
		            mSerialPort.ReadTimeout = mComTimeout;
		            mSerialPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
		            mSerialPort.Open();
		            Running = true;
				}
				catch(Exception ex){
					MsgLogger.PushMsg(Name, "Start", ex.Message);
					return false;
				}
			}
			foreach(CanbusDevice md in DeviceDict.Values)
			{
				md.Start();
			}
			MsgLogger.PushMsg(Name, "Start", "Success");			
			return true;
		}
		
		/// <summary>
		/// 停止设备
		/// </summary>
		/// <returns></returns>
		public bool Stop()
		{
			if(!Running) return true;
			mToRun = false;
			if((mSerialPort!= null) &&(mSerialPort.IsOpen))
			{
				try{
					mSerialPort.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
					mSerialPort.Close();
				}
				catch(Exception ex)
				{
					MsgLogger.PushMsg(Name, "Stop", ex.Message);
					return false;
				}
			}
			foreach(CanbusDevice md in DeviceDict.Values)
			{
				md.Stop();
			}
			MsgLogger.PushMsg(Name, "Stop", "Success");
			Running = false;
			return true;
		}
		
		/// <summary>
		/// event when serial port received data
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
			Thread.Sleep(5);
			int len = mSerialPort.BytesToRead;
			if(len <= 0)
				return;
			
			byte[] rcvdata = new byte[len];
			int rlen = mSerialPort.Read(rcvdata, 0, len);			
			if(rlen != len)
				return;
			mSerialPort.DiscardInBuffer();	
			MsgLogger.PushMsg(Name, "Receive", rcvdata);
			//响应
			byte[] rspdata;
			if(ParseMessage(rcvdata, out rspdata))
			{
				Thread.Sleep(mRespDelay);
				mSerialPort.Write(rspdata, 0, rspdata.Length);
				MsgLogger.PushMsg(Name, "Send", rspdata);
			}
		}
		
		
		/// <summary>
		/// 解析协议消息
		/// </summary>
		/// <param name="rcvBytes"></param>
		/// <param name="rspBytes"></param>
		/// <returns></returns>
		private bool ParseMessage(byte[] rcvBytes, out byte[] rspBytes)
		{
			rspBytes = null;
			int len = rcvBytes.Length;
			if(CBType == CanbusType.RectOne)
			{
				//判断长度
				if(len!=12) return false;
				byte addr = (byte)(rcvBytes[0]*2 + rcvBytes[1]/128);
				//检查地址是否有设备
				if(!DeviceDict.ContainsKey(addr)) return false;
				//设备处理消息
				CanbusDevice device = DeviceDict[rcvBytes[0]];
				return device.ParseCanMessage(rcvBytes, out rspBytes);
			}
			else if(CBType == CanbusType.RectTwo)
			{
				return false;
			}			
			return false;
		}		
	}
}
