using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCODatabaseLog
	{
		public POCODatabaseLog()
		{}

		public POCODatabaseLog(int databaseLogID,
		                       DateTime postTime,
		                       string databaseUser,
		                       string @event,
		                       string schema,
		                       string @object,
		                       string tSQL,
		                       string xmlEvent)
		{
			this.DatabaseLogID = databaseLogID.ToInt();
			this.PostTime = postTime.ToDateTime();
			this.DatabaseUser = databaseUser;
			this.@Event = @event;
			this.Schema = schema;
			this.@Object = @object;
			this.TSQL = tSQL;
			this.XmlEvent = xmlEvent;
		}

		public int DatabaseLogID {get; set;}
		public DateTime PostTime {get; set;}
		public string DatabaseUser {get; set;}
		public string @Event {get; set;}
		public string Schema {get; set;}
		public string @Object {get; set;}
		public string TSQL {get; set;}
		public string XmlEvent {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeDatabaseLogIDValue {get; set;} = true;

		public bool ShouldSerializeDatabaseLogID()
		{
			return ShouldSerializeDatabaseLogIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePostTimeValue {get; set;} = true;

		public bool ShouldSerializePostTime()
		{
			return ShouldSerializePostTimeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDatabaseUserValue {get; set;} = true;

		public bool ShouldSerializeDatabaseUser()
		{
			return ShouldSerializeDatabaseUserValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEventValue {get; set;} = true;

		public bool ShouldSerializeEvent()
		{
			return ShouldSerializeEventValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSchemaValue {get; set;} = true;

		public bool ShouldSerializeSchema()
		{
			return ShouldSerializeSchemaValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeObjectValue {get; set;} = true;

		public bool ShouldSerializeObject()
		{
			return ShouldSerializeObjectValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTSQLValue {get; set;} = true;

		public bool ShouldSerializeTSQL()
		{
			return ShouldSerializeTSQLValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeXmlEventValue {get; set;} = true;

		public bool ShouldSerializeXmlEvent()
		{
			return ShouldSerializeXmlEventValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeDatabaseLogIDValue = false;
			this.ShouldSerializePostTimeValue = false;
			this.ShouldSerializeDatabaseUserValue = false;
			this.ShouldSerializeEventValue = false;
			this.ShouldSerializeSchemaValue = false;
			this.ShouldSerializeObjectValue = false;
			this.ShouldSerializeTSQLValue = false;
			this.ShouldSerializeXmlEventValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>d7e8c175d7763434e4ce09a2dd8ca9b2</Hash>
</Codenesium>*/