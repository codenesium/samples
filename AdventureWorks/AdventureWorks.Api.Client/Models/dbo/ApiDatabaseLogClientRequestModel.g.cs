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
			string @event,
			string @object,
			string databaseUser,
			DateTime postTime,
			string schema,
			string tsql,
			string xmlEvent)
		{
			this.@Event = @event;
			this.@Object = @object;
			this.DatabaseUser = databaseUser;
			this.PostTime = postTime;
			this.Schema = schema;
			this.Tsql = tsql;
			this.XmlEvent = xmlEvent;
		}

		[JsonProperty]
		public string DatabaseUser { get; private set; } = default(string);

		[JsonProperty]
		public string @Event { get; private set; } = default(string);

		[JsonProperty]
		public string @Object { get; private set; } = default(string);

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
    <Hash>529a9fd0a97b6ff56f475840a5eb47ac</Hash>
</Codenesium>*/