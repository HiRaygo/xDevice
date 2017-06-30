/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/6/9
 * 时间: 19:11
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO.Ports;

namespace xDevice.Common
{
	/// <summary>
	/// Description of CANDevice.
	/// </summary>
	public class CANDevice: CommonDevice
	{
		SerialPort port;
		string mPortName;
		int mBaudRate;
		int mDataBits;
		StopBits mStopBits;
		Parity mParity;
		int mTimeoutR;
		
		public CANDevice(string name)
		{
			Name = name;
		}
		
		
		/// <summary>
		/// 设置设备的串口参数
		/// </summary>
		/// <param name="portname">串口号</param>
		/// <param name="baudrate">波特率</param>
		/// <param name="databits">数据位</param>
		/// <param name="stopbits">停止位</param>
		/// <param name="parity">校验位</param>
		/// <param name="timeout">读超时</param>
		public void SetParas(string portname, int baudrate, int databits, string stopbits, string parity, int timeout)
		{
			//串口号
			mPortName = portname;
			//波特率
			mBaudRate = baudrate;
			//数据位
			mDataBits = databits;
			//停止位
        	if(stopbits =="2")
        		mStopBits = StopBits.Two;
        	else if(stopbits == "1.5")
        		mStopBits = StopBits.OnePointFive;
        	else
        		mStopBits = StopBits.One;
        	//校验位
        	if(parity == "Even")
        		mParity = Parity.Even;
        	else if(parity == "Odd")
        		mParity = Parity.Odd;
        	else if(parity =="Mark")
        		mParity = Parity.Mark;
        	else
        		mParity = Parity.None;
        	//读超时
        	mTimeoutR = timeout;
        	//参数字符串
        	Para = portname +","+ baudrate.ToString() +","+ databits.ToString() +","+ stopbits +","+ parity;
		}
		
		/// <summary>
		/// 启动设备
		/// </summary>
		/// <returns></returns>
		public bool Start()
		{
			if((port == null) || (!port.IsOpen))
			{
				try{
					port = new SerialPort(mPortName, mBaudRate, mParity, mDataBits, mStopBits);
		            port.DataBits = mDataBits;
		            port.RtsEnable = true;
		            port.ReadTimeout = mTimeoutR;
		            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
		            port.Open();
				}
				catch(Exception ex){
					MsgLogger.PushMsg(Name, "Start", ex.Message);
					return false;
				}
			}		
			MsgLogger.PushMsg(Name, "Start", "Success");	
			Running = true;
			return true;
		}
		
		/// <summary>
		/// 停止设备
		/// </summary>
		/// <returns></returns>
		public bool Stop()
		{
			if(port!= null)
			{
				if(port.IsOpen)
				{
					try{
						port.Close();
					}
					catch(Exception ex)
					{
						MsgLogger.PushMsg(Name, "Stop", ex.Message);
						return false;
					}
				}
			}
			ReStart();
			
			MsgLogger.PushMsg(Name, "Stop", "Success");			
			Running = false;
			return true;
		}
		
	
		/// <summary>
		/// event when port received data
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
			int len = port.BytesToRead;
			if(len <= 0)
				return;
			
			byte[] rcvdata = new byte[len];
			int rlen = port.Read(rcvdata, 0, len);
			port.DiscardInBuffer();	
			if(rlen ==0)
				return;
			MsgLogger.PushMsg(Name, "Receive", rcvdata);
			
			int nom;
			byte[][] outdata;
			int[] delays;
			if(GetMatchedMesage(rcvdata, out nom, out outdata, out delays))
			{
				for(int i=0; i<nom; i++)
				{
					System.Threading.Thread.Sleep(delays[i]);
					port.Write(outdata[i], 0, outdata[i].Length);
					MsgLogger.PushMsg(Name, "Send", outdata[i]);
				}
			}
		}
	}
}
