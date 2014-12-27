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
		public void Add(DBContexts.Entity.Login InsertData, Dictionary<string, object> MetaData)
		{
			IXamarinIO iXamarinIo = new XamarinIO();
			iXamarinIo.Add(InsertData);			
		}

	}
}
