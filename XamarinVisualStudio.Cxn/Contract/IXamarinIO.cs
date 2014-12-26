using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamarinVisualStudio.Cxn.Contract
{
	public interface IXamarinIO
	{
		void Add(DBContexts.Entity.Login InsertData);
	}
}
