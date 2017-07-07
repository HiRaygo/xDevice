/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/5/21
 * 时间: 19:10
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace xDevice.Common
{
	/// <summary>
	/// Description of NetDevice.
	/// </summary>
	public class NetDevice: CommonDevice
	{
		string mDeviceIP;
		int mDevicePort;
		int mTimeout;

		Socket serverSocket;
		Hashtable AllClients;
		const int MAXCLIENTS = 10;
		const int RECEIVEBUFFERSIZE = 256;
		
		public NetDevice(string name, string para)
		{
			Running = false;
			AllClients = new Hashtable();
			
			Name = name;
			mDeviceIP = "127.0.0.1";
			mDevicePort = 65432;
			mTimeout = 3000;
			
			string[] tmp = para.Split(new char[]{',',':'});			
			if((tmp !=null) && (tmp.Length == 3))
			{				
				mDeviceIP = tmp[0];
				int.TryParse(tmp[1], out mDevicePort);
				int.TryParse(tmp[2], out mTimeout);
			}
			Para = mDeviceIP + ":"+ mDevicePort.ToString();
		}
				
		~NetDevice()
		{
			Stop();
		}
		
		/// <summary>
		/// 启动设备
		/// </summary>
		/// <returns></returns>
		public bool Start()
		{
			try
			{
				serverSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
				IPAddress ipa = IPAddress.Parse(mDeviceIP);
				IPEndPoint ipe= new IPEndPoint(ipa,mDevicePort);
				serverSocket.Bind(ipe);
				serverSocket.Listen(MAXCLIENTS);
				Thread lj = new Thread(new ThreadStart(WaitForConnect));
				lj.IsBackground = true;
				lj.Start();
			}
			catch(Exception ex)
			{
				MsgLogger.PushMsg(Name, "Start", ex.Message);
				return false;
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
			if(Running)
			{
				serverSocket.Close();
				Running = false;			
				MsgLogger.PushMsg(Name, "Stop", "Success");
			}
			ReStart();
			return true;
		}
		
		/// <summary>
		/// 等待客户端连接
		/// </summary>
		private void WaitForConnect()
		{
			while(Running)
			{
				Thread.Sleep(10);
				try{
					Socket client = serverSocket.Accept();
					object oj = client;
					Thread ml = new Thread(new ParameterizedThreadStart(ReceiveLoop));
					ml.IsBackground = true;
					ml.Start(oj);
				}
				catch(Exception ex){
					if(serverSocket != null)
						serverSocket.Close();
					Running = false;
					MsgLogger.PushMsg(Name, "Stop", ex.Message);
				}
			}
		}
		
		/// <summary>
		/// Message Loop
		/// </summary>
		/// <param name="cl"></param>
		private void ReceiveLoop(object cl)
		{
			Socket client = cl as Socket;
			if(client == null)
				return;
			string clientName = client.RemoteEndPoint.ToString();
			AllClients.Add(clientName,client);
			
			byte[] rbytes = new byte[RECEIVEBUFFERSIZE];
			int count;
			while(true)
			{
				count =0;
				try{
					count = client.Receive(rbytes);
					if(count>0)
					{
						string restr = Encoding.Default.GetString(rbytes);
						MsgLogger.PushMsg(clientName, "Receive", restr);
						
						byte[] sbytes = rbytes;
						client.Send(sbytes, sbytes.Length, SocketFlags.None);
						string sestr = Encoding.Default.GetString(sbytes);
						MsgLogger.PushMsg(clientName, "Send", sestr);
					}
				}
				catch{
					break;
				}
			}
			AllClients.Remove(clientName);
		}		
	}
}
