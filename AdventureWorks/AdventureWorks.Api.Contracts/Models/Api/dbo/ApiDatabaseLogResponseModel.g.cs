using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiDatabaseLogResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int databaseLogID,
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
    <Hash>2aff73cb41ffa0b04bc561933d622e88</Hash>
</Codenesium>*/