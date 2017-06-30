/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/5/12
 * 时间: 20:13
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace xDevice.Common
{
	/// <summary>
	/// Description of MatchRule.
	/// </summary>
	public class MatchRule
	{
		string strName,strIn,strOut;
		byte[] byIn, byOut;
		bool bEnable, bHex, bHead, bOnce, bNext;
		int iDealy;
		
		public string Name {get {return strName;}}
		public string InString {get {return strIn;}}
		public string OutString {get {return strOut;}}
		public byte[] InBytes {get {return byIn;}}
		public byte[] OutBytes {get {return byOut;}}		
		public bool Enable {get {return bEnable;}}
		public bool HexMode {get {return bHex;}}
		public bool MatchHead {get {return bHead;}}
		public bool MatchOnce {get {return bOnce;}}
		public bool MatchNext {get {return bNext;}}		
		public int Delayms {get {return iDealy;}}
		
		public bool Matched {set; get;}
		
		public MatchRule()
		{
			iDealy = 100;
			Matched = false;
		}
		
		public MatchRule(string name, string instring, string outstring, bool enable, bool hex, bool head, bool once, bool next, int delay)
		{
			strName = name;
			strIn = instring;
			strOut = outstring;			
			bEnable = enable;
			bHex = hex;
			bHead = head;
			bOnce = once;
			bNext = next;
			iDealy = delay;
			Matched = false;
			if(hex)
			{
				byIn = HexString.HexString2Bytes(instring);
				byOut = HexString.HexString2Bytes(outstring);
			}
			else
			{
				byIn = HexString.AsciiString2Bytes(instring);
				byOut = HexString.AsciiString2Bytes(outstring);
			}
		}
	}
}
