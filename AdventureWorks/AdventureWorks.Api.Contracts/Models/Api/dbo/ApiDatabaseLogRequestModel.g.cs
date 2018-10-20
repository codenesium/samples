using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiDatabaseLogRequestModel : AbstractApiRequestModel
	{
		public ApiDatabaseLogRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string databaseUser,
			string @event,
			string @object,
			DateTime postTime,
			string schema,
			string tsql,
			string xmlEvent)
		{
			this.DatabaseUser = databaseUser;
			this.@Event = @event;
			this.@Object = @object;
			this.PostTime = postTime;
			this.Schema = schema;
			this.Tsql = tsql;
			this.XmlEvent = xmlEvent;
		}

		[Required]
		[JsonProperty]
		public string DatabaseUser { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string @Event { get; private set; } = default(string);

		[JsonProperty]
		public string @Object { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime PostTime { get; private set; } = default(DateTime);

		[JsonProperty]
		public string Schema { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Tsql { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string XmlEvent { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>a84b0a016d2bbc3a10ab8dff89ba7e13</Hash>
</Codenesium>*/