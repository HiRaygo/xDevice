/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/5/21
 * 时间: 19:10
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;

namespace xDevice.Common
{
	/// <summary>
	/// Description of NetDeviceManager.
	/// </summary>
	public class NetDeviceManager
	{
		static Dictionary<string, NetDevice> DeviceList = new Dictionary<string, NetDevice>();
		static object obj = new object();
		
		/// <summary>
		/// 添加设备
		/// </summary>
		/// <param name="device"></param>
		public static bool AddDevice(NetDevice device)
		{
			lock(obj)
			{				
				if(DeviceList.ContainsKey(device.Name))
				{
					MsgLogger.PushMsg(device.Name, "Add", "Already exist.");
					return false;
				}
				else			
				{
					DeviceList.Add(device.Name, device);
					MsgLogger.PushMsg(device.Name, "Add", "Success.");
					return true;
				}
			}
		}
		
		/// <summary>
		/// 删除设备
		/// </summary>
		/// <param name="devicename"></param>
		public static bool DeleteDevice(string devicename)
		{
			lock(obj)
			{
				if(DeviceList.ContainsKey(devicename))
				{
					//停止设备
					NetDevice device;
					DeviceList.TryGetValue(devicename, out device);
					device.Stop();
					//删除
					DeviceList.Remove(devicename);
					MsgLogger.PushMsg(devicename, "Delete", "Success.");
					return true;
				}
				else
				{
					MsgLogger.PushMsg(devicename, "Delete", "Not exist.");
					return false;	
				}
			}
		}
		
		/// <summary>
		/// 删除所有设备
		/// </summary>
		public static void DeleteALLDevice()
		{
			lock(obj)
			{
				foreach(NetDevice device in DeviceList.Values)
				{
					//停止设备
					device.Stop();
				}
				DeviceList.Clear();
			}
		}
		
		/// <summary>
		/// 根据设备名获取设备
		/// </summary>
		/// <param name="devicename"></param>
		/// <param name="device"></param>
		/// <returns></returns>
		public static bool GetDeviceByName(string devicename, out NetDevice device)
		{
			lock(obj)
			{
				if(DeviceList.ContainsKey(devicename))
				{
					return DeviceList.TryGetValue(devicename, out device);			
				}
				else
				{
					device = null;
					return false;
				}	
			}
		}
		
		/// <summary>
		/// 获取设备信息列表
		/// </summary>
		/// <returns>设备名、设备参数列表</returns>
		public static string[][] GetDeviceInfo()
		{
			lock(obj)
			{
				int i = 0;
				string[][] info = new string[2][];
				info[0] = new string[(DeviceList.Count)];
				info[1] = new string[(DeviceList.Count)];
				foreach(NetDevice device in DeviceList.Values)
				{
					info[0][i] = device.Name;
					info[1][i] = device.Para;
					i++;
				}
				return info;
			}
		}
	}
}
