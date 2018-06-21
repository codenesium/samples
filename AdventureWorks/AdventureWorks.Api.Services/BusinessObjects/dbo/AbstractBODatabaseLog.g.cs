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
    <Hash>13205d97c137ecc64c6ad414672bddbe</Hash>
</Codenesium>*/