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
                public string DatabaseUser { get; private set; }

                [Required]
                [JsonProperty]
                public string @Event { get; private set; }

                [JsonProperty]
                public string @Object { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime PostTime { get; private set; }

                [JsonProperty]
                public string Schema { get; private set; }

                [Required]
                [JsonProperty]
                public string Tsql { get; private set; }

                [Required]
                [JsonProperty]
                public string XmlEvent { get; private set; }
        }
}

/*<Codenesium>
    <Hash>60324742ba384dbe57905bd13660c9bc</Hash>
</Codenesium>*/