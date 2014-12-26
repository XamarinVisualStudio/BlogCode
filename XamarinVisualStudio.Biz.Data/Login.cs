using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamarinVisualStudio.Biz.Data
{
    public class Login
    {
		public int UserID { get; set; }
		public Guid rowguid { get; set; }
		public string UserName { get; set; }
		public string UserPassword { get; set; }
		public DateTime DTCreate { get; set; }
		public DateTime DTUpdate { get; set; }
    }
}
