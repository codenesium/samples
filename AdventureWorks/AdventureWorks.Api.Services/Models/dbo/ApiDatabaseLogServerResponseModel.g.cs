using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiDatabaseLogServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int databaseLogID,
			string databaseUser,
			DateTime postTime,
			string reservedEvent,
			string reservedObject,
			string schema,
			string tsql,
			string xmlEvent)
		{
			this.DatabaseLogID = databaseLogID;
			this.DatabaseUser = databaseUser;
			this.PostTime = postTime;
			this.ReservedEvent = reservedEvent;
			this.ReservedObject = reservedObject;
			this.Schema = schema;
			this.Tsql = tsql;
			this.XmlEvent = xmlEvent;
		}

		[JsonProperty]
		public int DatabaseLogID { get; private set; }

		[JsonProperty]
		public string DatabaseUser { get; private set; }

		[JsonProperty]
		public string ReservedEvent { get; private set; }

		[Required]
		[JsonProperty]
		public string ReservedObject { get; private set; }

		[JsonProperty]
		public DateTime PostTime { get; private set; }

		[Required]
		[JsonProperty]
		public string Schema { get; private set; }

		[JsonProperty]
		public string Tsql { get; private set; }

		[JsonProperty]
		public string XmlEvent { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9bd455431005675467c518344d73857c</Hash>
</Codenesium>*/