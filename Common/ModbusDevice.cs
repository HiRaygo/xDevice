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
	//数据更新模式
	public enum FileDownState
	{
		Ready = 0,
		Started,
		Loading,
		Loaded,
		Finish,
		Activating,
		Activated,
		Error
	}
	
	//数据更新模式
	public enum FileUpState
	{
		Ready = 0,
		Started,
		Loading,
		Loaded,
		Finish,
		Finished,
		Error
	}
	
	//数据更新模式
	public enum UpdateMode
	{
		Const = 0,
		Random,
		StepAdd,
		StepDec,
		RollD,
		RollA
	}
	
	/// <summary>
	/// Description of ModbusData.
	/// </summary>
	public class ModbusData
	{
		public string Name;
		public UInt16 Addr;
		public Int16 Value;
		//public Int16 StartValue;
		public Int16 HLimit;
		public Int16 LLimit;
		public Int16 Step;
		public UpdateMode Umode;		
		
		public ModbusData(string name, UInt16 addr)
		{
			Name = name;
			Addr = addr;
			Value = 0;
			//StartValue = 0;
			HLimit = 0;
			LLimit = 0;
			Step = 0;
			Umode = UpdateMode.Const;
		}
		
		public ModbusData(string name, UInt16 addr, UpdateMode mode, Int16 val, Int16 llimit, Int16 hlimit, Int16 step)
		{
			Name = name;
			Addr = addr;
			Umode = mode;
			Value = val;
			HLimit = hlimit;
			LLimit = llimit;
			Step = step;			
		}
	}
	
	/// <summary>
	/// Description of FileData.
	/// </summary>
	public class FileData
	{
		public byte Type;
		public byte[] Data;
		public int uFrameLen, dFrameLen;	
		
		public FileData(byte type, int length)
		{
			Type = type;
			Data = new byte[length];
			uFrameLen = 224;
			dFrameLen = 224;
		}
		
		public FileData(byte type, byte[] data)
		{
			Type = type;
			Data = data;
			uFrameLen = 224;
			dFrameLen = 224;			
		}
	}
	/// <summary>
	/// Description of ModbusDevice.
	/// </summary>
	public class ModbusDevice
	{
		public string Name;
		public byte Address;
		public bool Running;
		
		Dictionary<int, ModbusData> mDataRegs;	
		Dictionary<byte, FileData> mFiles;			
		bool mToRun;
		int mLastTime;
		object obj = new object();
		//文件加载、上传状态
		FileDownState mDState;
		FileUpState mUState;
		int mFrameId;
		
		public ModbusDevice(string name, byte addr)
		{
			Name = name;
			Address = addr;
			mToRun = false;
			mDataRegs = new Dictionary<int, ModbusData>();
			mFiles = new Dictionary<byte, FileData>();
		}
		
		/// <summary>
		/// 添加寄存器
		/// </summary>
		/// <param name="regaddr"></param>
		/// <param name="regdata"></param>
		public bool AddReg(int regaddr, ModbusData regdata)
		{
			if(mDataRegs.ContainsKey(regaddr))
				return false;
			mDataRegs.Add(regaddr, regdata);
			return true;
		}
		
		/// <summary>
		/// 获取寄存器列表
		/// </summary>
		/// <param name="regaddr"></param>
		/// <param name="regdata"></param>
		public List<ModbusData> GetRegs()
		{
			List<ModbusData> dlist = new List<ModbusData>();
			foreach(ModbusData data in mDataRegs.Values)
			{
				dlist.Add(data);
			}
			return dlist;
		}
		
		/// <summary>
		/// 从xml文件导入配置
		/// </summary>
		/// <param name="filename">文件名</param>
		public bool ImportFromXml(string filename)
		{
			lock(obj)
			{
				mDataRegs.Clear();
				XmlNodeList nlist, flist;
				try{
					XmlDocument xmlDoc=new XmlDocument(); 
					xmlDoc.Load(filename);
					XmlNode root = xmlDoc.SelectSingleNode("Root");
					nlist = root.SelectSingleNode("Regs").ChildNodes;
					flist = root.SelectSingleNode("Files").ChildNodes;
				}
				catch{
					return false;
				}
				//寄存器数据
				string name;
				UInt16 addr;
				Int16 val, hlimit, llimit, step;
				UpdateMode mode;
				foreach(XmlNode xn in nlist)
				{
					XmlElement xe = (XmlElement)xn;
					try{						
						name = xe.GetAttribute("Name");
						addr = UInt16.Parse(xe.GetAttribute("Address"));
						val = Int16.Parse(xe.GetAttribute("Value"));
						llimit = Int16.Parse(xe.GetAttribute("LLimit"));
						hlimit = Int16.Parse(xe.GetAttribute("HLimit"));
						step = Int16.Parse(xe.GetAttribute("Step"));
						switch(xe.GetAttribute("Mode"))
						{
							case "Const":
								mode = UpdateMode.Const;
								break;
							case "Random":
								mode = UpdateMode.Random;
								break;
							case "RollA":
								mode = UpdateMode.RollA;
								break;
							case "RollD":
								mode = UpdateMode.RollD;
								break;
							case "StepAdd":
								mode = UpdateMode.StepAdd;
								break;
							case "StepDec":
								mode = UpdateMode.StepDec;
								break;
							default:
								mode = UpdateMode.Const;
								break;
						}
					}
					catch{
						return false;
					}
					mDataRegs.Add(addr, new ModbusData(name,addr, mode, val, llimit, hlimit, step));
				}
				//寄存器数据
				byte type;
				byte[] data;
				foreach(XmlNode xn in flist)
				{
					XmlElement xe = (XmlElement)xn;
					try{
						type = byte.Parse(xe.GetAttribute("Type"));
						data = HexString.HexString2Bytes(xe.InnerText);
					}
					catch{
						return false;
					}
					mFiles.Add(type, new FileData(type,data));
				}
				return true;
			}
		}
		
		/// <summary>
		/// 导出设备配置到xml文件
		/// </summary>
		/// <param name="filename">文件名</param>
		public void ExportToXml(string filename)
		{
			lock(obj)
			{
				XmlTextWriter xmlWriter;
				xmlWriter = new XmlTextWriter(filename, Encoding.Default);
				xmlWriter.Formatting = Formatting.Indented;
				xmlWriter.WriteStartDocument();
				xmlWriter.WriteStartElement("Root");
				//寄存器数据
				xmlWriter.WriteStartElement("Regs");				
				foreach(ModbusData reg in mDataRegs.Values)
				{
					xmlWriter.WriteStartElement("Reg");
					xmlWriter.WriteAttributeString("Name", reg.Name);
					xmlWriter.WriteAttributeString("Address", reg.Addr.ToString());
					xmlWriter.WriteAttributeString("Value", reg.Value.ToString());
					xmlWriter.WriteAttributeString("Mode", reg.Umode.ToString());
					xmlWriter.WriteAttributeString("LLimit", reg.LLimit.ToString());
					xmlWriter.WriteAttributeString("HLimit", reg.HLimit.ToString());
					xmlWriter.WriteAttributeString("Step", reg.Step.ToString());
					xmlWriter.WriteEndElement();
				}				
				xmlWriter.WriteEndElement();
				//文件数据
				xmlWriter.WriteStartElement("Files");				
				foreach(FileData file in mFiles.Values)
				{
					xmlWriter.WriteStartElement("File");
					xmlWriter.WriteAttributeString("Type", file.Type.ToString());
					xmlWriter.WriteString(HexString.Bytes2HexString(file.Data));
					xmlWriter.WriteEndElement();
				}				
				xmlWriter.WriteEndElement();
				//结尾
				xmlWriter.WriteEndElement();
				xmlWriter.Close();
			}
		}
		
		/// <summary>
		/// 刷新寄存器信息
		/// </summary>
		private void UpdateRegs()
		{
			Running = true;
			while(mToRun)
			{
				Thread.Sleep(200);
				Random rd = new Random();
				int nowtime = DateTime.Now.Second;
				if(mLastTime == nowtime)
					continue;
				else
					mLastTime = nowtime;
						
				foreach(ModbusData data in mDataRegs.Values)
				{					
					switch(data.Umode)
					{
						case UpdateMode.Random:
							data.Value = (Int16)(rd.Next(data.LLimit, data.HLimit));
							break;
						case UpdateMode.StepAdd:
							if(data.HLimit <= data.Value)
							{
								data.Value = data.HLimit;
							}
							else
							{
								data.Value++;
							}
							break;
						case UpdateMode.StepDec:
							if(data.Value <= data.LLimit)
							{
								data.Value = data.LLimit;
							}
							else
							{
								data.Value--;
							}
							break;
						case UpdateMode.RollD:
							Int16 tmp3 = data.Value;
							if(tmp3 == 0)
								data.Value = 1;
							else
								data.Value = 0;
							break;
						case UpdateMode.RollA:
							Int16 tmp4 = data.Value;
							if(tmp4 == data.HLimit)
								data.Value = data.LLimit;
							else
								data.Value = data.HLimit;
							break;
						default :
							break;
					}
				}
			}
			Running = false;
		}
		
		/// <summary>
		/// 启动设备
		/// </summary>
		/// <returns></returns>
		public bool Start()
		{
			mToRun = true;			
			mLastTime	= DateTime.Now.Second;
			Thread thdUpdateRegs = new Thread(new ThreadStart(UpdateRegs));
			thdUpdateRegs.IsBackground = true;
			thdUpdateRegs.Start();	
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
			MsgLogger.PushMsg(Name, "Stop", "Success.");			
			return true;
		}
		
		
		/// <summary>
		/// 解析RTU消息
		/// </summary>
		/// <param name="recvBytes"></param>
		/// <param name="respBytes"></param>
		/// <returns></returns>
		public bool ParseRTUMessage(byte[] rcvBytes, out byte[] rspBytes)
		{	
			if(!Running)
			{
				rspBytes = null;
				return false;
			}
			byte[] tmpBytes;
			if(ParseMessage(rcvBytes, out tmpBytes))
			{
				//加上CRC
				rspBytes = CRC.AddCRC(tmpBytes);
				return true;
			}
			else
			{
				rspBytes = null;
				return false;
			}
		}		
		
		/// <summary>
		/// 解析TCP消息
		/// </summary>
		/// <param name="rcvBytes">接收到的TCP数据</param>
		/// <param name="rspBytes">响应的数据</param>
		/// <returns></returns>
		public bool ParseTCPMessage(byte[] rcvBytes, out byte[] rspBytes)
		{
			//取其中的有效字段：地址+功能码+数据,补上CRC
			int len = rcvBytes.Length;
			byte[] rcvdata = new byte[len-4];
			for(int i =0; i< len-6; i++)
			{
				rcvdata[i] = rcvBytes[6+i];
			}
			//补上前字段
			byte[] tmpBytes;
			if(ParseMessage(rcvdata, out tmpBytes))
			{
				rspBytes = new byte[tmpBytes.Length + 6];
				rspBytes[0] = rcvBytes[0];
				rspBytes[1] = rcvBytes[1];
				rspBytes[2] = rcvBytes[2];
				rspBytes[3] = rcvBytes[3];
				rspBytes[4] = rcvBytes[4];
				rspBytes[5] = (byte)(tmpBytes.Length);
				for(int j=0; j<tmpBytes.Length; j++)
				{
					rspBytes[6+j] = tmpBytes[j];
				}
				return true;
			}
			else
			{
				rspBytes = null;
				return false;
			}
		}
		
		/// <summary>
		/// 解析消息
		/// </summary>
		/// <param name="rcvBytes"></param>
		/// <param name="rspBytes"></param>
		/// <returns></returns>
		private bool ParseMessage(byte[] rcvBytes, out byte[] rspBytes)
		{			
			rspBytes = null;
			if(rcvBytes[1] == 0x03)
			{
				return ReadRegs(rcvBytes, out rspBytes);
			}
			else if(rcvBytes[1] == 0x06)
			{
				return WriteSingleReg(rcvBytes, out rspBytes);
			}
			else if(rcvBytes[1] == 0x10)
			{
				return WriteMultReg(rcvBytes, out rspBytes);
			}
			else if(rcvBytes[1] == 0x41)
			{
				if((rcvBytes[2] > 0) &&(rcvBytes[2] <5))
					return FileDownload(rcvBytes, out rspBytes);
				else if((rcvBytes[2] == 5) || (rcvBytes[2] == 6)||(rcvBytes[2] == 0x0c))
					return FileUpload(rcvBytes, out rspBytes);
				else
					return false;					
			}
			else
			{
				return false;
			}
		}
		
		/// <summary>
		/// 读寄存器
		/// </summary>
		/// <param name="rcvBytes"></param>
		/// <param name="rspBytes"></param>
		/// <returns></returns>
		private bool ReadRegs(byte[] rcvBytes, out byte[] rspBytes)
		{
			rspBytes = null;
			if(rcvBytes.Length ==8)
			{
				int regaddr = rcvBytes[2] *256 + rcvBytes[3];
				int regnum = rcvBytes[4] *256 + rcvBytes[5];
				//判断寄存器是否存在
				for(int i=0; i<regnum; i++)
				{
					if(!mDataRegs.ContainsKey(regaddr+i))
					{
						rspBytes = new byte[3];
						rspBytes[0] = rcvBytes[0];
						rspBytes[1] = 0x83;
						rspBytes[2] = 0x02;
						return true;
					}
				}
				rspBytes = new byte[3+2*regnum];
				rspBytes[0] = rcvBytes[0];
				rspBytes[1] = rcvBytes[1];
				rspBytes[2] = (byte)(2*regnum);
				//读取寄存器的值
				for(int j=0;j<regnum;j++)
				{
					rspBytes[3+2*j] = (byte)(mDataRegs[regaddr+j].Value / 256);
					rspBytes[4+2*j] = (byte)(mDataRegs[regaddr+j].Value % 256);
				}
				return true;
			}
			return false;
		}
		
		/// <summary>
		/// 写单个寄存器
		/// </summary>
		/// <param name="rcvBytes"></param>
		/// <param name="rspBytes"></param>
		/// <returns></returns>
		private bool WriteSingleReg(byte[] rcvBytes, out byte[] rspBytes)
		{
			rspBytes = null;
			int regaddr = rcvBytes[2] *256 + rcvBytes[3];
			if(rcvBytes.Length == 8)
			{			
				//判断寄存器是否存在
				if(!mDataRegs.ContainsKey(regaddr))
				{
					rspBytes = new byte[3];
					rspBytes[0] = rcvBytes[0];
					rspBytes[1] = 0x86;
					rspBytes[2] = 0x02;
					return true;
				}
				//写入值到寄存器
				mDataRegs[regaddr].Value = (Int16)(rspBytes[4] * 256 + rspBytes[5]);
				rspBytes = new byte[6];
				rspBytes[0] = rcvBytes[0];
				rspBytes[1] = rcvBytes[1];
				rspBytes[2] = rcvBytes[2];
				rspBytes[3] = rcvBytes[3];
				rspBytes[4] = rcvBytes[4];
				rspBytes[5] = rcvBytes[5];
				return true;
			}
			return false;
		}
		
		/// <summary>
		/// 写多个寄存器
		/// </summary>
		/// <param name="rcvBytes"></param>
		/// <param name="rspBytes"></param>
		/// <returns></returns>
		private bool WriteMultReg(byte[] rcvBytes, out byte[] rspBytes)
		{
			rspBytes = null;
			int regaddr = rcvBytes[2] *256 + rcvBytes[3];
			int regnum = rcvBytes[4] *256 + rcvBytes[5];
			if((rcvBytes.Length == (rcvBytes[6] +9)) &&(2*regnum == rcvBytes[6]))
			{			
				//判断寄存器是否存在
				for(int i=0; i<regnum; i++)
				{
					if(!mDataRegs.ContainsKey(regaddr+i))
					{
						rspBytes = new byte[3];
						rspBytes[0] = rcvBytes[0];
						rspBytes[1] = 0x90;
						rspBytes[2] = 0x02;
						return true;
					}
				}
				//写入值到寄存器
				for(int j=0;j<regnum;j++)
				{
					mDataRegs[regaddr+j].Value = (Int16)(rspBytes[7+2*j] * 256 + rspBytes[8+2*j]);
				}
				rspBytes = new byte[6];
				rspBytes[0] = rcvBytes[0];
				rspBytes[1] = rcvBytes[1];
				rspBytes[2] = rcvBytes[2];
				rspBytes[3] = rcvBytes[3];
				rspBytes[4] = rcvBytes[4];
				rspBytes[5] = rcvBytes[5];
				return true;
			}
			return false;
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
				if(datalen != 6) return false;
				int filelen = ((int)rcvBytes[5])<<24 + ((int)rcvBytes[6])<<16 +((int)rcvBytes[7])<<8 + rcvBytes[8];
				FileData file = new FileData(filetype, filelen);
				file.dFrameLen = (rcvBytes[9] >224)? 224: rcvBytes[9];
				if(mFiles.ContainsKey(filetype))
				{
					mFiles[filetype] = file;
				}
				else
				{
					mFiles.Add(filetype, file);					
				}
				//返回数据
				rspBytes = new byte[10];
				for(int i=0; i<9; i++)
				{
					rspBytes[i] = rcvBytes[i];
				}
				rspBytes[9] = (byte)(file.dFrameLen);
				mDState = FileDownState.Started;
				return true;
			}
			//状态循环
			switch(mDState)
			{
				case FileDownState.Started:
					if(childcode == 0x02)
					{
						if(!mFiles.ContainsKey(filetype)) return false;						
						if(datalen < 4) return false;
						if((rcvBytes[5] !=0)|| (rcvBytes[6]!=0)) return false;
						//长度是否为多帧
						int framelen = rcvBytes[7];
						FileData file = mFiles[filetype];
						int len;
						if(framelen >= file.Data.Length)
						{
							len = file.Data.Length;
							mDState = FileDownState.Loaded;
						}
						else
						{
							len = framelen;
							mDState = FileDownState.Loading;
						}
						//赋值给文件
						for(int j=0; j< len; j++)
						{
							file.Data[j] = rcvBytes[8+j];
						}
						//返回数据
						rspBytes = new byte[8];
						for(int i=0; i<7; i++)
						{
							rspBytes[i] = rcvBytes[i];
						}
						rspBytes[3] = 4;
						rspBytes[7] = (byte)(len);
						return true;
					}
					break;
				case FileDownState.Loading:
					if(childcode == 0x02)
					{
						if(!mFiles.ContainsKey(filetype)) return false;						
						if(datalen < 4) return false;
						mFrameId = rcvBytes[5]*256 + rcvBytes[6];
						if(mFrameId <1 ) return false;
						//长度
						int framelen = rcvBytes[7];
						FileData file = mFiles[filetype];
						int len;
						if(framelen >= file.dFrameLen)
						{
							len = file.dFrameLen;
						}
						else
						{
							len = framelen;
						}
						//赋值给文件
						for(int j=0; j< len; j++)
						{
							file.Data[mFrameId*file.dFrameLen+j] = rcvBytes[8+j];
						}
						//返回数据
						rspBytes = new byte[8];
						for(int i=0; i<7; i++)
						{
							rspBytes[i] = rcvBytes[i];
						}
						rspBytes[3] = 4;
						rspBytes[7] = (byte)(len);
						if(mFrameId* file.dFrameLen + len == file.Data.Length)
							mDState = FileDownState.Finish;
						return true;
					}
					break;
				case FileDownState.Loaded:
					if(childcode == 0x03)
					{												
						if(datalen != 3) return false;
						if(!mFiles.ContainsKey(filetype)) return false;
						FileData file = mFiles[filetype];
						byte[] crc16 = CRC.CRC16(file.Data);
						//CRC校验
						if(rcvBytes[5] != crc16[1] || rcvBytes[6] != crc16[0])
						{
							rspBytes = new byte[3];
							rspBytes[0] = rcvBytes[0];
							rspBytes[1] = 0xC1;
							rspBytes[2] = 0x08;
							mDState = FileDownState.Error;
							return true;
						}
						//返回数据
						rspBytes = new byte[7];
						for(int i=0; i<7; i++)
						{
							rspBytes[i] = rcvBytes[i];
						}
						mDState = FileDownState.Finish;
						return true;
					}
					break;
				case FileDownState.Finish:
					if(childcode == 0x04)
					{												
						if(datalen != 1) return false;
						if(!mFiles.ContainsKey(filetype)) return false;
						//返回数据
						rspBytes = new byte[6];
						rspBytes[0] = rcvBytes[0];
						rspBytes[1] = rcvBytes[1];
						rspBytes[2] = rcvBytes[2];
						rspBytes[3] = 2;
						rspBytes[4] = rcvBytes[4];
						rspBytes[5] = 0;
						mDState = FileDownState.Activating;
						return true;
					}
					break;
				case FileDownState.Activating:
					mDState = FileDownState.Activated;
					break;
				default:
					break;
			}			
			return false;
		}
		
		/// <summary>
		/// 文件上传
		/// </summary>
		/// <param name="rcvBytes"></param>
		/// <param name="rspBytes"></param>
		/// <returns></returns>
		private bool FileUpload(byte[] rcvBytes, out byte[] rspBytes)
		{
			rspBytes = null;
			byte childcode = rcvBytes[2];
			byte datalen = rcvBytes[3];
			byte filetype = rcvBytes[4];
			//判断长度
			if(rcvBytes.Length != datalen+6)
				return false;
			//启动加载
			if(childcode == 0x05)
			{				
				if(!mFiles.ContainsKey(filetype))
				{
					rspBytes = new byte[3];
					rspBytes[0] = rcvBytes[0];
					rspBytes[1] = 0xC1;
					rspBytes[2] = 0x08;
					return true;
				}
				FileData file = mFiles[filetype];
				int filelen = file.Data.Length;
				//返回数据
				rspBytes = new byte[10];
				rspBytes[0] = rcvBytes[0];
				rspBytes[1] = 0x41;
				rspBytes[2] = 0x05;
				rspBytes[3] = 0x06;
				rspBytes[4] = rcvBytes[4];
				rspBytes[5] = (byte)(filelen>>24);
				rspBytes[6] = (byte)(filelen>>16);
				rspBytes[7] = (byte)(filelen>>8);
				rspBytes[8] = (byte)(filelen%256);
				rspBytes[9] = (byte)(file.uFrameLen);
				mUState = FileUpState.Started;
				return true;
			}
			//状态循环
			switch(mUState)
			{
				case FileUpState.Started:
					if(childcode == 0x06)
					{
						if(!mFiles.ContainsKey(filetype)) return false;						
						if(datalen != 3) return false;						
						mFrameId = rcvBytes[5]*256 + rcvBytes[6];
						if(mFrameId != 0) return false;
						//是否只有一帧
						FileData file = mFiles[filetype];
						int len;
						if(file.uFrameLen >= file.Data.Length)
						{
							len = file.Data.Length;
							mUState = FileUpState.Loaded;
						}
						else
						{
							len = file.uFrameLen;
							mUState = FileUpState.Loading;
						}
						//返回数据
						rspBytes = new byte[7+len];
						rspBytes[0] = rcvBytes[0];
						rspBytes[1] = rcvBytes[1];
						rspBytes[2] = rcvBytes[2];
						rspBytes[3] = (byte)(3+len);
						rspBytes[4] = rcvBytes[4];
						rspBytes[5] = rcvBytes[5];
						rspBytes[6] = rcvBytes[6];
						for(int j=0; j< len; j++)
						{
							rspBytes[7+j]  = file.Data[j];
						}
						return true;
					}
					break;
				case FileUpState.Loading:
					if(childcode == 0x06)
					{
						if(!mFiles.ContainsKey(filetype)) return false;						
						if(datalen != 3) return false;						
						mFrameId = rcvBytes[5]*256 + rcvBytes[6];
						if(mFrameId < 1) return false;
						//是否只有一帧
						FileData file = mFiles[filetype];
						int len;
						int gettedlen = file.uFrameLen*mFrameId;
						if(file.uFrameLen >= (file.Data.Length - gettedlen))
						{
							len = file.Data.Length-gettedlen;
							mUState = FileUpState.Loaded;
						}
						else
						{
							len = file.uFrameLen;
							mUState = FileUpState.Loading;
						}
						//返回数据
						rspBytes = new byte[7+len];
						rspBytes[0] = rcvBytes[0];
						rspBytes[1] = rcvBytes[1];
						rspBytes[2] = rcvBytes[2];
						rspBytes[3] = (byte)(3+len);
						rspBytes[4] = rcvBytes[4];
						rspBytes[5] = rcvBytes[5];
						rspBytes[6] = rcvBytes[6];
						for(int j=0; j< len; j++)
						{
							rspBytes[7+j]  = file.Data[j+gettedlen];
						}
						return true;
					}
					break;
				case FileUpState.Loaded:
					if(childcode == 0x0c)
					{												
						if(datalen != 1) return false;
						if(!mFiles.ContainsKey(filetype)) return false;
						FileData file = mFiles[filetype];
						byte[] crc16 = CRC.CRC16(file.Data);
						//返回数据
						rspBytes = new byte[7];
						rspBytes[0] = rcvBytes[0];
						rspBytes[1] = rcvBytes[1];
						rspBytes[2] = rcvBytes[2];
						rspBytes[3] = 0x03;
						rspBytes[4] = rcvBytes[4];
						rspBytes[5] = crc16[1];
						rspBytes[6] = crc16[0];
						mUState = FileUpState.Finish;
						return true;
					}
					break;
				default:
					break;
			}			
			return false;
		}
	}
}
