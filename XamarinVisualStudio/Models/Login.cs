using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace XamarinVisualStudio.Models
{
	public class Login : BlogData
	{
		public int UserID { get; set; }
		public Guid rowguid { get; set; }
		public string UserName { get; set; }
		public string UserPassword { get; set; }
		public DateTime DTCreate { get; set; }
		public DateTime DTUpdate { get; set; }
	}
}
