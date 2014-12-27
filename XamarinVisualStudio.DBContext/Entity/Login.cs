using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Web;

namespace XamarinVisualStudio.DBContexts.Entity
{
	public class Login
	{
		
		public int Id { get; set; }
		public Guid rowguid { get; set; }
		public string UserName { get; set; }
		public string UserPassword { get; set; }
		public DateTime DTCreate { get; set; }
		public DateTime DTUpdate { get; set; }
	}
}
