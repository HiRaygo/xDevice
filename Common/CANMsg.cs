/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/6/9
 * 时间: 19:17
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace xDevice.Common
{
	public enum CANDataType
	{
		I = 0,
		II,
		III,
		IV,
		V,
		VI,
		VII
	}
	/// <summary>
	/// Description of CANMsgID.
	/// </summary>
	public struct CANMsg
	{
		//信号ID
		ushort mMsgID;
		public string MsgID;
		//数据类型
		CANDataType mDataType;
		public string DataType;
		//说明信息
		public string Desc;
		//值
		//byte[] mValue;
		public string Value;
		//可读
		bool mCanRead;
		public string CanRead;
		//可写
		bool mCanWrite;
		public string CanWrite;
		
		public CANMsg(string msgid, string datatype, string desc, string value, string canread, string canwrite)
		{
			MsgID = msgid;
			DataType = datatype;
			Desc = desc;
			Value = value;
			CanRead = canread;
			CanWrite = canwrite;
			
			if(!ushort.TryParse(msgid, out mMsgID))				
			{
				mMsgID = 0;
				MsgID = "0x0000";
			}
			
			switch(datatype)
			{
				case "I":
					mDataType = CANDataType.I;
					break;
				case "II":
					mDataType = CANDataType.II;
					break;
				case "III":
					mDataType = CANDataType.III;
					break;
				case "IV":
					mDataType = CANDataType.IV;
					break;
				case "V":
					mDataType = CANDataType.V;
					break;
				case "VI":
					mDataType = CANDataType.VI;
					break;
				case "VII":
					mDataType = CANDataType.VII;
					break;
				default:
					mDataType = CANDataType.I;
					DataType = "I";
					break;
			}
			
			switch(canread)
			{
				case "True":
					mCanRead = true;
					break;
				case "False":
					mCanRead = false;
					break;
				default:
					mCanRead = false;
					CanRead = "False";
					break;
			}
			
			switch(canwrite)
			{
				case "True":
					mCanWrite = true;
					break;
				case "False":
					mCanWrite = false;
					break;
				default:
					mCanWrite = false;
					CanWrite = "False";
					break;
			}
		}
	}
}
