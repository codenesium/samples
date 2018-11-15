using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiDatabaseLogClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int databaseLogID,
			string @event,
			string @object,
			string databaseUser,
			DateTime postTime,
			string schema,
			string tsql,
			string xmlEvent)
		{
			this.DatabaseLogID = databaseLogID;
			this.@Event = @event;
			this.@Object = @object;
			this.DatabaseUser = databaseUser;
			this.PostTime = postTime;
			this.Schema = schema;
			this.Tsql = tsql;
			this.XmlEvent = xmlEvent;
		}

		[JsonProperty]
		public int DatabaseLogID { get; private set; }

		[JsonProperty]
		public string DatabaseUser { get; private set; }

		[JsonProperty]
		public string @Event { get; private set; }

		[JsonProperty]
		public string @Object { get; private set; }

		[JsonProperty]
		public DateTime PostTime { get; private set; }

		[JsonProperty]
		public string Schema { get; private set; }

		[JsonProperty]
		public string Tsql { get; private set; }

		[JsonProperty]
		public string XmlEvent { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3a0c75dfc7b4c5780235b97ffcb69f54</Hash>
</Codenesium>*/