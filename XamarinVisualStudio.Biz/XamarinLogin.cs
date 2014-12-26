using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinVisualStudio.Cxn;
using XamarinVisualStudio.Cxn.Contract;
using DBContextLogin = XamarinVisualStudio.DBContexts.Entity;
using BizLogin = XamarinVisualStudio.Biz.Data;

namespace XamarinVisualStudio.Biz{

    public class XamarinLogin
    {
		public XamarinLogin()
		{
			Mapper.CreateMap<BizLogin.Login, DBContextLogin.Login >();
		}
		public void Add(BizLogin.Login bizLogin, Dictionary<string, object> MetaData)
		{
			int i = 0;
			DBContextLogin.Login login = Mapper.Map<BizLogin.Login,DBContextLogin.Login>(bizLogin);
			IXamarinGateway iXamarinGateway = new XamarinGateWay();
			iXamarinGateway.Add(login, MetaData);
		}
    }
}
