using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBODatabaseLog : AbstractBusinessObject
	{
		public AbstractBODatabaseLog()
			: base()
		{
		}

		public virtual void SetProperties(int databaseLogID,
		                                  string databaseUser,
		                                  string @event,
		                                  string @object,
		                                  DateTime postTime,
		                                  string schema,
		                                  string tsql,
		                                  string xmlEvent)
		{
			this.DatabaseLogID = databaseLogID;
			this.DatabaseUser = databaseUser;
			this.@Event = @event;
			this.@Object = @object;
			this.PostTime = postTime;
			this.Schema = schema;
			this.Tsql = tsql;
			this.XmlEvent = xmlEvent;
		}

		public int DatabaseLogID { get; private set; }

		public string DatabaseUser { get; private set; }

		public string @Event { get; private set; }

		public string @Object { get; private set; }

		public DateTime PostTime { get; private set; }

		public string Schema { get; private set; }

		public string Tsql { get; private set; }

		public string XmlEvent { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9217a6b1aa12f1c9e15d71123ba920ef</Hash>
</Codenesium>*/