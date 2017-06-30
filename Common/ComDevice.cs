/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/5/12
 * 时间: 23:09
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO.Ports;

namespace xDevice.Common
{
	/// <summary>
	/// Description of ComDevice.
	/// </summary>
	public class ComDevice: CommonDevice
	{
		SerialPort port;
		string mPortName;
		int mTimeOut;
		
		public ComDevice(string name)
		{
			Name = name;
		}
		
		public ComDevice(string name, string para)
		{
			Name = name;
			mPortName = "COM1";
			mTimeOut = 1000;
			
			string[] tmp = para.Split(new char[]{',',':'});			
			if(tmp !=null)
			{
				if(tmp.Length ==1)
					mPortName = tmp[0];
				else if(tmp.Length ==2)
				{
					mPortName = tmp[0];
					int.TryParse(tmp[1], out mTimeOut);
				}
			}
			Para = mPortName + ","+ mTimeOut.ToString();
		}
		
		~ComDevice()
		{
			Stop();
		}
		
		/// <summary>
		/// 设置设备的串口参数
		/// </summary>
		/// <param name="portname">串口号</param>
		/// <param name="timeout">超时</param>
		public void SetParas(string portname, int timeout)
		{
			//串口号
			mPortName = portname;
			mTimeOut = timeout;
        	//参数字符串
        	Para = portname + ","+ timeout.ToString();
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
					port = new SerialPort(mPortName, 9600, Parity.None, 8, StopBits.One);
		            port.RtsEnable = true;
		            port.ReadTimeout = mTimeOut;
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
				MsgLogger.PushMsg(Name, "Stop", "Success");	
			}
			ReStart();					
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
