using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiDatabaseLogResponseModel: AbstractApiResponseModel
	{
		public ApiDatabaseLogResponseModel() : base()
		{}

		public void SetProperties(
			int databaseLogID,
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

		[JsonIgnore]
		public bool ShouldSerializeDatabaseLogIDValue { get; set; } = true;

		public bool ShouldSerializeDatabaseLogID()
		{
			return this.ShouldSerializeDatabaseLogIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDatabaseUserValue { get; set; } = true;

		public bool ShouldSerializeDatabaseUser()
		{
			return this.ShouldSerializeDatabaseUserValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEventValue { get; set; } = true;

		public bool ShouldSerializeEvent()
		{
			return this.ShouldSerializeEventValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeObjectValue { get; set; } = true;

		public bool ShouldSerializeObject()
		{
			return this.ShouldSerializeObjectValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePostTimeValue { get; set; } = true;

		public bool ShouldSerializePostTime()
		{
			return this.ShouldSerializePostTimeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSchemaValue { get; set; } = true;

		public bool ShouldSerializeSchema()
		{
			return this.ShouldSerializeSchemaValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTSQLValue { get; set; } = true;

		public bool ShouldSerializeTSQL()
		{
			return this.ShouldSerializeTSQLValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeXmlEventValue { get; set; } = true;

		public bool ShouldSerializeXmlEvent()
		{
			return this.ShouldSerializeXmlEventValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeDatabaseLogIDValue = false;
			this.ShouldSerializeDatabaseUserValue = false;
			this.ShouldSerializeEventValue = false;
			this.ShouldSerializeObjectValue = false;
			this.ShouldSerializePostTimeValue = false;
			this.ShouldSerializeSchemaValue = false;
			this.ShouldSerializeTSQLValue = false;
			this.ShouldSerializeXmlEventValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>a0f2f8b8b822e616d0d75213a86a914a</Hash>
</Codenesium>*/