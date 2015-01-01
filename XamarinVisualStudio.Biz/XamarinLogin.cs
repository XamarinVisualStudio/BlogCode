using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinVisualStudio.Cxn;
using XamarinVisualStudio.Cxn.Contract;
using DBContextLogin = XamarinVisualStudio.DBContexts.Entity;
using BizLogin = XamarinVisualStudio.Biz.Data;
using HashLib;

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
			MetaData["Username"] = DecryptLoginString(MetaData);
			MetaData["UserName"] = "test";
			MetaData["Password"] = "test";
			DBContexts.Entity.Login _login = iXamarinGateway.Find(MetaData);
			if (_login != null)
				return Mapper.Map<DBContextLogin.Login, BizLogin.Login>(_login);
			else
				return null;
		}
		private static string DecryptLoginString(Dictionary<string,object> MetaData)
		{
			char[] b = ((Convert.ToInt64(MetaData)) / 23).ToString("X").ToCharArray();
			Array.Reverse(b);
			string HexValue = new string(b);
			string StrValue = "";
			while (HexValue.Length > 0)
			{
				StrValue += System.Convert.ToChar(System.Convert.ToUInt32(HexValue.Substring(0, 2), 16)).ToString();
				HexValue = HexValue.Substring(2, HexValue.Length - 2);
			}
			return StrValue = EncryptString(StrValue);
		}
		private static string EncryptString(string passPhrase)
		{
			IHash hash = HashFactory.Crypto.SHA3.CreateKeccak512();
			HashResult r = hash.ComputeString(passPhrase, System.Text.Encoding.ASCII);
			return r.ToString().ToLower().Replace("-", "");
		}
	}
}
