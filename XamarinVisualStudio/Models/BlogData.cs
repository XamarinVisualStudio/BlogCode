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
	public class BlogData
	{
		public int BlogID { get; set; }
		public Guid rowguid { get; set; }
		public string BlogTitle { get; set; }
		public string BlogText { get; set; }
        public bool UltraZipTech { get; set; }
		public DateTime DTCreate { get; set; }
		public DateTime DTUpdate { get; set; }
	}
}
