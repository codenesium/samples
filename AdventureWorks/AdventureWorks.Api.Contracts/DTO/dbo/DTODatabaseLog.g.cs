using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTODatabaseLog: AbstractDTO
	{
		public DTODatabaseLog() : base()
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

		public int DatabaseLogID { get; set; }
		public string DatabaseUser { get; set; }
		public string @Event { get; set; }
		public string @Object { get; set; }
		public DateTime PostTime { get; set; }
		public string Schema { get; set; }
		public string TSQL { get; set; }
		public string XmlEvent { get; set; }
	}
}

/*<Codenesium>
    <Hash>f37a7ca7953591ae667885c5bdc384ae</Hash>
</Codenesium>*/