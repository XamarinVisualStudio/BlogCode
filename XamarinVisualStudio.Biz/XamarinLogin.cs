using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinVisualStudio.Cxn;
using XamarinVisualStudio.Cxn.Contract;
using DBContextLogin = XamarinVisualStudio.DBContexts.Entity;
using BizLogin = XamarinVisualStudio.Biz.Data;

namespace XamarinVisualStudio.Biz
{

	public class XamarinLogin
	{
		IXamarinGateway iXamarinGateway = new XamarinGateWay();
		public XamarinLogin()
		{
			Mapper.CreateMap<BizLogin.Login, DBContextLogin.Login>();
			Mapper.CreateMap<DBContextLogin.Login, BizLogin.Login>();
		}
		public void Add(BizLogin.Login bizLogin, Dictionary<string, object> MetaData)
		{
			DBContextLogin.Login login = Mapper.Map<BizLogin.Login, DBContextLogin.Login>(bizLogin);
			IXamarinGateway iXamarinGateway = new XamarinGateWay();
			iXamarinGateway.Add(login, MetaData);
		}
		public void Update(BizLogin.Login bizLogin, Dictionary<string, object> MetaData)
		{
			DBContextLogin.Login login = Mapper.Map<BizLogin.Login, DBContextLogin.Login>(bizLogin);

			iXamarinGateway.Update(login, MetaData);
		}
		public BizLogin.Login Validate(Dictionary<string, object> MetaData)
		{
			MetaData["Username"] = DecryptString(MetaData);
			return Mapper.Map<DBContextLogin.Login, BizLogin.Login>(iXamarinGateway.Find(MetaData));			
		}
		private static string DecryptString(Dictionary<string, object> MetaData)
		{
			char[] b = ((Convert.ToInt64(MetaData["Username"])) / 23).ToString("X").ToCharArray();
			Array.Reverse(b);
			string HexValue = new string(b);		
			string StrValue = "";
			while (HexValue.Length > 0)
			{
				StrValue += System.Convert.ToChar(System.Convert.ToUInt32(HexValue.Substring(0, 2), 16)).ToString();
				HexValue = HexValue.Substring(2, HexValue.Length - 2);
			}
			return StrValue;

		}
	}
}
