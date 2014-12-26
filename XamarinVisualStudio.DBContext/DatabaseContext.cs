using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using XamarinVisualStudio.DBContexts.Entity;

namespace XamarinVisualStudio.DBContexts
{
	public class DatabaseContext : DbContext
	{
		public DbSet<Login> DBLogin { get; set; }
		public DatabaseContext()
			: base()
		{
			string connectionString = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["XamarinDBConString"]);
			Database.Connection.ConnectionString = connectionString;
		}
	}
}
