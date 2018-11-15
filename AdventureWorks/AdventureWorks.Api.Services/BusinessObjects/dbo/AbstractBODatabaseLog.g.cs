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
			this.DatabaseLogID = databaseLogID;
			this.DatabaseUser = databaseUser;
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
    <Hash>84868b0752d47f7a32bc2a88a3bfae10</Hash>
</Codenesium>*/