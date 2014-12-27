using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinVisualStudio.Cxn.Contract;

namespace XamarinVisualStudio.Cxn.Impl
{
	public class XamarinIO : IXamarinIO
	{
		public void Add(DBContexts.Entity.Login InsertData)
		{
			using(var context = new  DBContexts.XamarinsDB())
			{
				context.DBLogin.Add(InsertData);
				context.SaveChanges();				
			}
		}
		public string test()
		{
			return "";
		}


	}
}
