using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BODatabaseLog: AbstractBusinessObject
	{
		public BODatabaseLog() : base()
		{}

		public void SetProperties(int databaseLogID,
		                          string databaseUser,
		                          string @event,
		                          string @object,
		                          DateTime postTime,
		                          string schema,
		                          string tSQL,
		                          string xmlEvent)
		{
			this.DatabaseLogID = databaseLogID.ToInt();
			this.DatabaseUser = databaseUser;
			this.@Event = @event;
			this.@Object = @object;
			this.PostTime = postTime.ToDateTime();
			this.Schema = schema;
			this.TSQL = tSQL;
			this.XmlEvent = xmlEvent;
		}

		public int DatabaseLogID { get; private set; }
		public string DatabaseUser { get; private set; }
		public string @Event { get; private set; }
		public string @Object { get; private set; }
		public DateTime PostTime { get; private set; }
		public string Schema { get; private set; }
		public string TSQL { get; private set; }
		public string XmlEvent { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3e88e067edaecd4f1e3b3bb58204f979</Hash>
</Codenesium>*/