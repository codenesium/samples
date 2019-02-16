using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiDatabaseLogServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiDatabaseLogServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string databaseUser,
			DateTime postTime,
			string schema,
			string tsql,
			string xmlEvent)
		{
			this.DatabaseUser = databaseUser;
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
		public DateTime PostTime { get; private set; } = SqlDateTime.MinValue.Value;

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
    <Hash>1397502c3064f99457ee629dc1682523</Hash>
</Codenesium>*/