using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinVisualStudio.Cxn.Contract;
using XamarinVisualStudio.Cxn.Impl;

namespace XamarinVisualStudio.Cxn
{
	public class XamarinGateWay : IXamarinGateway
	{
		IXamarinIO iXamarinIo = new XamarinIO();
		public void Add(DBContexts.Entity.Login InsertData, Dictionary<string, object> MetaData)
		{			
			iXamarinIo.Add(InsertData);			
		}
		public void Update(DBContexts.Entity.Login InsertData, Dictionary<string, object> MetaData)
		{			
			iXamarinIo.Update(InsertData);
		}
		public DBContexts.Entity.Login Find(Dictionary<string,object> Metadata)
		{
			return iXamarinIo.Find(Metadata);
		}
	}
}
