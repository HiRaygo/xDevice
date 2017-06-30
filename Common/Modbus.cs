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
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace xDevice.Common
{
	public enum ModbusType
	{
		RTU = 0,
		TCP,
		ASCII
	}
		
	/// <summary>
	/// Description of ModbusDevice.
	/// </summary>
	public class Modbus
	{
		public string Name;			
		public string CommParas;
		public ModbusType MBType;		
		public bool Running;
		
		Dictionary<byte, ModbusDevice> DeviceDict;
		Dictionary<byte, string> DeviceNameDict;
		bool mToRun;
		int mCommType;
		int mRespDelay;
		//串口参数
		string mComPort;
		int mComTimeout;
		SerialPort mSerialPort;
		//网口参数
		string mNetIP;
		int mNetPort;
		int mNetTimeout;
		Socket mServer;
		Hashtable mClients;
		
		public Modbus(string name)
		{
			Name = name;
			mToRun = false;
			mCommType = 0;
			Running = false;
			DeviceDict = new Dictionary<byte, ModbusDevice>();
			DeviceNameDict = new Dictionary<byte, string>();
		}
		
		public Modbus(string name, string commparas)
		{
			Name = name;
			CommParas = commparas;
			mToRun = false;
			mCommType = 0;
			Running = false;
			DeviceDict = new Dictionary<byte, ModbusDevice>();
			DeviceNameDict = new Dictionary<byte, string>();
			ParseParas();			
		}
		
		/// <summary>
		/// 设置参数
		/// </summary>
		/// <param name="commparas">通讯参数</param>
		/// <param name="addr">地址</param>
		/// <param name="mbtype">Modbus类型</param>
		public bool SetParas(string commparas, ModbusType mbtype)
		{
			CommParas = commparas;
			MBType = mbtype;
			return ParseParas();
		}
		
		/// <summary>
		/// 增加设备
		/// </summary>
		/// <param name="device"></param>
		/// <returns></returns>
		public bool AddDevice(ModbusDevice device)
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
			foreach(ModbusDevice device in DeviceDict.Values)
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
		public bool GetDeviceByName(string devicename, out ModbusDevice device)
		{
			foreach(ModbusDevice dv in DeviceDict.Values)
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
			foreach(ModbusDevice device in DeviceDict.Values)
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
				mCommType = 1;
				string[] paras = CommParas.Split(new char[]{','});
				if((paras != null) && (paras.Length == 4))
				{
					mComPort = paras[0];
					mComTimeout = int.Parse(paras[1]);
					mRespDelay = int.Parse(paras[2]);
					if(paras[3] == "RTU")
						MBType = ModbusType.RTU;
					else if(paras[3] == "TCP")
						MBType = ModbusType.TCP;
					else
						return false;
				}
				else
					return false;
			}
			else
			{
				mCommType = 2;
				string[] paras = CommParas.Split(new char[]{',',':'});
				if((paras != null) && (paras.Length == 5))
				{
					mNetIP = paras[0];
					mNetPort = int.Parse(paras[1]);
					mNetTimeout = int.Parse(paras[2]);
					mRespDelay = int.Parse(paras[3]);
					if(paras[4] == "RTU")
						MBType = ModbusType.RTU;
					else if(paras[4] == "TCP")
						MBType = ModbusType.TCP;
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
			if(mCommType == 1)
			{
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
			}
			else if(mCommType == 2)
			{
				try
				{
					mServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
					IPEndPoint ipe= new IPEndPoint(IPAddress.Parse(mNetIP), mNetPort);
					mServer.Bind(ipe);
					mServer.Listen(10);
					mClients = new Hashtable();
					Thread lj = new Thread(new ThreadStart(WaitForConnect));
					lj.IsBackground = true;
					lj.Start();
					Running = true;
				}
				catch(Exception ex)
				{
					MsgLogger.PushMsg(Name, "Start", ex.Message);
					return false;
				}				
			}
			foreach(ModbusDevice md in DeviceDict.Values)
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
			if(mCommType == 1)
			{
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
			}
			else if(mCommType == 2)
			{
				if(Running)
				{
					mServer.Close();
					mClients.Clear();					
				}				
			}
			foreach(ModbusDevice md in DeviceDict.Values)
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
		/// 等待客户端连接
		/// </summary>
		private void WaitForConnect()
		{
			while(mToRun)
			{
				Thread.Sleep(10);
				try{
					Socket client = mServer.Accept();
					object oj = client;
					Thread ml = new Thread(new ParameterizedThreadStart(ReceiveLoop));
					ml.IsBackground = true;
					ml.Start(oj);					
				}
				catch(Exception ex)
				{
					if(mServer != null)
						mServer.Close();
					MsgLogger.PushMsg(Name, "Stop", ex.Message);
					break;
				}
			}
			Running = false;
		}
		
		/// <summary>
		/// net Message Loop
		/// </summary>
		/// <param name="cl"></param>
		private void ReceiveLoop(object cl)
		{
			Socket client = cl as Socket;
			if(client == null)
				return;
			string clientName = client.RemoteEndPoint.ToString();
			mClients.Add(clientName,client);
			
			byte[] rbytes = new byte[256];
			int count;
			while(mToRun)
			{
				count = 0;
				try{
					count = client.Receive(rbytes);
					if(count>0)
					{
						byte[] rcvdata = new byte[count];
						for(int i=0; i<count; i++)
						{
							rcvdata[i] = rbytes[i];
						}
						MsgLogger.PushMsg(Name, "Receive", rcvdata);
						byte[] rspdata;
						if(ParseMessage(rcvdata, out rspdata))
						{
							Thread.Sleep(mRespDelay);
							client.Send(rspdata);
							MsgLogger.PushMsg(Name, "Send", rspdata);
						}
					}
				}
				catch{
					break;
				}
			}
			mClients.Remove(clientName);
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
			if(MBType == ModbusType.RTU)
			{
				//判断长度
				if(len<7) return false;
				//校验CRC
				if(!CRC.CheckCRC(rcvBytes)) return false;
				//检查地址是否有设备
				if(!DeviceDict.ContainsKey(rcvBytes[0])) return false;
				//设备处理消息
				ModbusDevice device = DeviceDict[rcvBytes[0]];
				return device.ParseRTUMessage(rcvBytes, out rspBytes);
			}
			else if(MBType == ModbusType.TCP)
			{
				//判断长度
				if(len<8) return false;
				//校验长度
				if(len != (rcvBytes[5] + 6)) return false;
				//检查地址是否有设备
				if(!DeviceDict.ContainsKey(rcvBytes[6])) return false;
				//设备处理消息
				ModbusDevice device = DeviceDict[rcvBytes[6]];
				return device.ParseTCPMessage(rcvBytes, out rspBytes);
			}			
			return false;
		}		
	}
}
