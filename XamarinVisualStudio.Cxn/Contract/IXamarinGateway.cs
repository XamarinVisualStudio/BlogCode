using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamarinVisualStudio.Cxn.Contract
{
	public interface IXamarinGateway
	{
		void Add(DBContexts.Entity.Login InsertData, Dictionary<string, object> MetaData);
		void Update(DBContexts.Entity.Login InsertData, Dictionary<string, object> MetaData);
		DBContexts.Entity.Login Find(Dictionary<string, object> Metadata);
	}
}
