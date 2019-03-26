using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiDatabaseLogClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiDatabaseLogClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string databaseUser,
			DateTime postTime,
			string reservedEvent,
			string reservedObject,
			string schema,
			string tsql,
			string xmlEvent)
		{
			this.DatabaseUser = databaseUser;
			this.PostTime = postTime;
			this.ReservedEvent = reservedEvent;
			this.ReservedObject = reservedObject;
			this.Schema = schema;
			this.Tsql = tsql;
			this.XmlEvent = xmlEvent;
		}

		[JsonProperty]
		public string DatabaseUser { get; private set; } = default(string);

		[JsonProperty]
		public string ReservedEvent { get; private set; } = default(string);

		[JsonProperty]
		public string ReservedObject { get; private set; } = default(string);

		[JsonProperty]
		public DateTime PostTime { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Schema { get; private set; } = default(string);

		[JsonProperty]
		public string Tsql { get; private set; } = default(string);

		[JsonProperty]
		public string XmlEvent { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>c5b87545ca5698d0ea26dfec821288b3</Hash>
</Codenesium>*/