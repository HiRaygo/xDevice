/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/5/13
 * 时间: 9:07
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;

namespace xDevice.Common
{
	/// <summary>
	/// Description of ComDeviceManager.
	/// </summary>
	public class CanbusManager
	{
		static Dictionary<string, Canbus> CanbusDict = new Dictionary<string, Canbus>();
		static object objc = new object();		
	
		/// <summary>
		/// 添加
		/// </summary>
		/// <param name="bus"></param>
		public static bool AddCanbus(Canbus bus)
		{
			lock(objc)
			{				
				if(CanbusDict.ContainsKey(bus.Name))
				{
					MsgLogger.PushMsg(bus.Name, "Add", "Fail, already exist.");
					return false;
				}
				else			
				{
					CanbusDict.Add(bus.Name, bus);
					MsgLogger.PushMsg(bus.Name, "Add", "Success.");
					return true;
				}
			}
		}
		
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="busname"></param>
		public static bool DeleteCanbus(string busname)
		{
			lock(objc)
			{
				if(CanbusDict.ContainsKey(busname))
				{
					//停止
					Canbus bus;
					CanbusDict.TryGetValue(busname, out bus);
					bus.Stop();
					//删除
					CanbusDict.Remove(busname);
					MsgLogger.PushMsg(busname, "Delete", "Success.");
					return true;				
				}
				else
				{
					MsgLogger.PushMsg(busname, "Delete", "Fail, not exist.");
					return false;	
				}
			}
		}
		
		/// <summary>
		/// 删除所有总线
		/// </summary>
		public static void DeleteALLCanbus()
		{
			lock(objc)
			{
				foreach(Canbus bus in CanbusDict.Values)
				{
					//停止
					bus.Stop();	
				}
				CanbusDict.Clear();
			}
		}
		
		/// <summary>
		/// 根据设备名获取设备
		/// </summary>
		/// <param name="busname"></param>
		/// <param name="bus"></param>
		/// <returns></returns>
		public static bool GetCanbusByName(string busname, out Canbus bus)
		{
			lock(objc)
			{
				if(CanbusDict.ContainsKey(busname))
				{
					return CanbusDict.TryGetValue(busname, out bus);			
				}
				else
				{
					bus = null;
					return false;
				}	
			}
		}
		
		/// <summary>
		/// 获取Can总线列表
		/// </summary>
		/// <returns>总线名、参数列表</returns>
		public static string[][] GetCanDeviceInfo()
		{
			lock(objc)
			{
				int i = 0;
				string[][] info = new string[2][];
				info[0] = new string[(CanbusDict.Count)];
				info[1] = new string[(CanbusDict.Count)];
				foreach(Canbus bus in CanbusDict.Values)
				{
					info[0][i] = bus.Name;
					info[1][i] = bus.CommParas;
					i++;
				}
				return info;
			}
		}
	}
}
