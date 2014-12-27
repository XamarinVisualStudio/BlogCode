using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using XamarinVisualStudio.DBContexts.Entity;

namespace XamarinVisualStudio.DBContexts
{
	public class XamarinsDB : DbContext
	{
		public DbSet<Login> DBLogin { get; set; }
		public XamarinsDB()
			: base()
		{
			string connectionString = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["XamarinDBConString"]);
			Database.Connection.ConnectionString = connectionString;
		}
	}
}
