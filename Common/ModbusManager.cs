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
	public class ModbusManager
	{
		static Dictionary<string, Modbus> ModbusDict = new Dictionary<string, Modbus>();
		static object obj = new object();		
	
		/// <summary>
		/// 添加
		/// </summary>
		/// <param name="bus"></param>
		public static bool AddModbus(Modbus bus)
		{
			lock(obj)
			{				
				if(ModbusDict.ContainsKey(bus.Name))
				{
					MsgLogger.PushMsg(bus.Name, "Add", "Fail, already exist.");
					return false;
				}
				else			
				{
					ModbusDict.Add(bus.Name, bus);
					MsgLogger.PushMsg(bus.Name, "Add", "Success.");
					return true;
				}
			}
		}
		
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="busname"></param>
		public static bool DeleteModbus(string busname)
		{
			lock(obj)
			{
				if(ModbusDict.ContainsKey(busname))
				{
					//停止
					Modbus bus;
					ModbusDict.TryGetValue(busname, out bus);
					bus.Stop();
					//删除
					ModbusDict.Remove(busname);
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
		public static void DeleteALLModbus()
		{
			lock(obj)
			{
				foreach(Modbus bus in ModbusDict.Values)
				{
					//停止
					bus.Stop();	
				}
				ModbusDict.Clear();
			}
		}
		
		/// <summary>
		/// 根据设备名获取设备
		/// </summary>
		/// <param name="busname"></param>
		/// <param name="bus"></param>
		/// <returns></returns>
		public static bool GetModbusByName(string busname, out Modbus bus)
		{
			lock(obj)
			{
				if(ModbusDict.ContainsKey(busname))
				{
					return ModbusDict.TryGetValue(busname, out bus);			
				}
				else
				{
					bus = null;
					return false;
				}	
			}
		}
		
		/// <summary>
		/// 获取总线列表
		/// </summary>
		/// <returns>总线名、参数列表</returns>
		public static string[][] GetDeviceInfo()
		{
			lock(obj)
			{
				int i = 0;
				string[][] info = new string[2][];
				info[0] = new string[(ModbusDict.Count)];
				info[1] = new string[(ModbusDict.Count)];
				foreach(Modbus bus in ModbusDict.Values)
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
