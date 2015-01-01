using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using XamarinVisualStudio.Cxn.Contract;

namespace XamarinVisualStudio.Cxn.Impl
{
	public class XamarinIO : IXamarinIO
	{
		public void Add(DBContexts.Entity.Login InsertData)
		{
			using (var context = new DBContexts.XamarinsDB())
			{
				context.DBLogin.Add(InsertData);
				context.SaveChanges();
			}
		}
		public void Update(DBContexts.Entity.Login InsertData)
		{
			using (var context = new DBContexts.XamarinsDB())
			{
				var UpdateLogin = context.DBLogin.Find(InsertData.Id);
				context.Entry(UpdateLogin).State = EntityState.Modified;
				context.SaveChanges();
			}
		}
		public DBContexts.Entity.Login Find(Dictionary<string, object> Metadata)
		{
			string str = Convert.ToString(Metadata["UserName"]);
			string pwd = Convert.ToString(Metadata["Password"]);
			using (var context = new DBContexts.XamarinsDB())
			{
				var UserInfo = context.DBLogin.Where(m => m.UserName == str && m.UserPassword == pwd).FirstOrDefault();
				return UserInfo;
			}
		}
	}
}
