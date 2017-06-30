/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/5/12
 * 时间: 20:42
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace xDevice.Common
{
	/// <summary>
	/// Description of Device.
	/// </summary>
	public class CommonDevice
	{
		//名称
		public string Name;
		//参数字符串
		public string Para;
		//运行状态
		public bool Running;
		//响应规则
		private List<MatchRule> RuleList = new List<MatchRule>();
		//锁
		private object obj = new object();
		
		public CommonDevice()
		{
			
		}
		
		/// <summary>
		/// 新建设备并设置名称和参数
		/// </summary>
		/// <param name="name"></param>
		/// <param name="para"></param>
		public CommonDevice(string name)
		{
			Name = name;
		}
		
		~CommonDevice()
		{
			if(RuleList!=null)
			{
				RuleList.Clear();
			}
		}
		
	
		public void ReStart()
		{
			lock(obj)
			{
				foreach(MatchRule rl in RuleList)
				{
					rl.Matched = false;
				}
			}
		}
		/// <summary>
		/// 获取设备的匹配规则
		/// </summary>
		/// <returns></returns>
		public List<MatchRule> GetRules()
		{
			lock(obj)
			{
				return RuleList;
			}
		}
		
				
		/// <summary>
		/// 设置设备的匹配规则
		/// </summary>
		/// <param name="list"></param>
		public void SetRules(List<MatchRule> list)
		{
			lock(obj)
			{
				RuleList = list;
			}
		}
		
		/// <summary>
		/// 添加一条规则到规则列表
		/// </summary>
		/// <param name="rule"></param>
		public void AddRule(MatchRule rule)
		{
			lock(obj)
			{
				RuleList.Add(rule);
			}
		}
		
		/// <summary>
		/// 从规则列表中删除一条规则
		/// </summary>
		/// <param name="index">规则序号</param>
		public void DeleteRule(int index)
		{
			lock(obj)
			{
				RuleList.RemoveAt(index);
			}
		}
		
		/// <summary>
		/// 替换规则列表中的一条规则
		/// </summary>
		/// <param name="index">规则序号</param>
		/// <param name="newrule">新规则</param>
		public void ReplaceRule(int index, MatchRule newrule)
		{
			lock(obj)
			{
				RuleList.RemoveAt(index);
				RuleList.Insert(index, newrule);
			}
		}
		
		/// <summary>
		/// 将规则列表中的一条规则上移
		/// </summary>
		/// <param name="index">规则序号</param>
		public void UpRule(int index)
		{
			lock(obj)
			{
				if((index < 1) || (index >= RuleList.Count)) return;
				MatchRule rule = RuleList[index];
				RuleList.RemoveAt(index);
				RuleList.Insert(index -1, rule);
			}
		}
		
		/// <summary>
		/// 将规则列表中的一条规则下移
		/// </summary>
		/// <param name="index">规则序号</param>
		public void DownRule(int index)
		{
			lock(obj)
			{
				if((index < 0) || (index >= RuleList.Count -1)) return;
				MatchRule rule = RuleList[index];
				RuleList.RemoveAt(index);
				RuleList.Insert(index +1, rule);
			}
		}
		
		/// <summary>
		/// 从xml文件导入规则到设备
		/// </summary>
		/// <param name="filename">文件名</param>
		public bool ImportRulesFromXml(string filename)
		{
			lock(obj)
			{
				RuleList.Clear();
				XmlNodeList nlist;
				try{
					XmlDocument xmlDoc=new XmlDocument(); 
					xmlDoc.Load(filename);
					nlist = xmlDoc.SelectSingleNode("Rules").ChildNodes;
				}
				catch{
					return false;
				}
				
				int delayms = 100;
				string name, instr, outstr;
				bool enable, hex, once, head, next;
				foreach(XmlNode xn in nlist)
				{
					XmlElement xe = (XmlElement)xn;
					try{
						delayms = int.Parse(xe.GetAttribute("Delayms"));
						enable = (xe.GetAttribute("Enable") == "True")? true:false;
						hex = (xe.GetAttribute("Hex") == "True")? true:false;
						once = (xe.GetAttribute("MatchOnce") == "True")? true:false;
						head = (xe.GetAttribute("MatchHead") == "True")? true:false;
						next = (xe.GetAttribute("MatchNext") == "True")? true:false;
						
						name = xe.GetAttribute("Name");
						instr = xe.GetAttribute("InData");					
						outstr = xe.InnerText;						
					}
					catch{
						return false;
					}
					RuleList.Add(new MatchRule(name,instr, outstr, enable, hex, head, once, next, delayms));
				}
				return true;
			}
		}
		
		/// <summary>
		/// 导出设备匹配规则到xml文件
		/// </summary>
		/// <param name="filename">文件名</param>
		public void ExportRulesToXml(string filename)
		{
			lock(obj)
			{
				XmlTextWriter xmlWriter;
				xmlWriter = new XmlTextWriter(filename, Encoding.Default);
				xmlWriter.Formatting = Formatting.Indented;
				xmlWriter.WriteStartDocument();
				xmlWriter.WriteStartElement("Rules");
				
				foreach(MatchRule mr in RuleList)
				{
					xmlWriter.WriteStartElement("Rule");
					xmlWriter.WriteAttributeString("Name", mr.Name);
					
					if(mr.Enable)
						xmlWriter.WriteAttributeString("Enable", "True");
					else
						xmlWriter.WriteAttributeString("Enable", "False");
					
					if(mr.HexMode)
						xmlWriter.WriteAttributeString("Hex", "True");
					else
						xmlWriter.WriteAttributeString("Hex", "False");
					
					if(mr.MatchHead)
						xmlWriter.WriteAttributeString("MatchHead", "True");
					else
						xmlWriter.WriteAttributeString("MatchHead", "False");
					
					if(mr.MatchOnce)
						xmlWriter.WriteAttributeString("MatchOnce", "True");
					else
						xmlWriter.WriteAttributeString("MatchOnce", "False");
										
					if(mr.MatchNext)
						xmlWriter.WriteAttributeString("MatchNext", "True");
					else
						xmlWriter.WriteAttributeString("MatchNext", "False");
					
					xmlWriter.WriteAttributeString("Delayms", mr.Delayms.ToString());
					xmlWriter.WriteAttributeString("InData",mr.InString);
					xmlWriter.WriteString(mr.OutString);
					xmlWriter.WriteEndElement();
				}
				
				xmlWriter.WriteEndElement();
				xmlWriter.Close();
			}
		}
		
		/// <summary>
		/// 根据输入数据获取匹配的数据
		/// </summary>
		/// <param name="indata"></param>
		/// <param name="NoM"></param>
		/// <param name="mdata"></param>
		/// <param name="delays"></param>
		/// <returns></returns>
		protected bool GetMatchedMesage(byte[] indata, out int NoM, out byte[][] mdata, out int[] delays)
		{
			lock(obj)
			{
				NoM = 0;
				mdata = new byte[10][];			
				delays = new int[10];
				
				foreach(MatchRule rule in RuleList)
				{
					//if not enable, check the next
					if(!rule.Enable)
						continue;
					//if only matched one time, check the next
					if(rule.MatchOnce && rule.Matched)
						continue;
					
					//get the matched item
					//Check the message length
					byte[] rbyte = rule.InBytes;
					if(indata.Length < rbyte.Length)
						continue;
					
					//match all but length not match
					if((!rule.MatchHead) && (indata.Length != rbyte.Length))
						continue;
	
					int i =0;
					while(i< rule.InBytes.Length)
					{
						if(indata[i] != rbyte[i])
							break;
						i++;
					}
					if(i < rbyte.Length)
						continue;
													
					//get the matched msg					
					mdata[NoM] = rule.OutBytes;				
					delays[NoM] = rule.Delayms;				
					NoM++;
					rule.Matched = true;
					
					//continue to match the next one or not
					if(rule.MatchNext)
						continue;
					else
						break;
				}
				
				//return the matched info
				if(NoM == 0)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}
	}
}
