using Codenesium.DataConversionExtensions.AspNetCore;
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
                                                  string tSQL,
                                                  string xmlEvent)
                {
                        this.DatabaseLogID = databaseLogID;
                        this.DatabaseUser = databaseUser;
                        this.@Event = @event;
                        this.@Object = @object;
                        this.PostTime = postTime;
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
        }
}

/*<Codenesium>
    <Hash>772fe594f8e5c5e003d6e9f59178227f</Hash>
</Codenesium>*/