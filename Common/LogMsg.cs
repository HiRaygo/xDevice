/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/5/12
 * 时间: 20:47
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace xDevice.Common
{
	/// <summary>
	/// Description of LogMsg.
	/// </summary>
	public class LogMsg
	{
		public string Time;
		public string Device;
		public string Action;
		public string Data;
		
		public LogMsg()
		{
			Time = DateTime.Now.TimeOfDay.ToString();
		}
		
		public LogMsg(string device, string action, string data)
		{
			Time = DateTime.Now.TimeOfDay.ToString();
			Device = device;
			Action = action;
			Data = data;
		}
	}
}
