using Codenesium.DataConversionExtensions.AspNetCore;
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

                public void SetProperties(
                        string databaseUser,
                        string @event,
                        string @object,
                        DateTime postTime,
                        string schema,
                        string tSQL,
                        string xmlEvent)
                {
                        this.DatabaseUser = databaseUser;
                        this.@Event = @event;
                        this.@Object = @object;
                        this.PostTime = postTime;
                        this.Schema = schema;
                        this.TSQL = tSQL;
                        this.XmlEvent = xmlEvent;
                }

                private string databaseUser;

                [Required]
                public string DatabaseUser
                {
                        get
                        {
                                return this.databaseUser;
                        }

                        set
                        {
                                this.databaseUser = value;
                        }
                }

                private string @event;

                [Required]
                public string @Event
                {
                        get
                        {
                                return this.@event;
                        }

                        set
                        {
                                this.@event = value;
                        }
                }

                private string @object;

                public string @Object
                {
                        get
                        {
                                return this.@object.IsEmptyOrZeroOrNull() ? null : this.@object;
                        }

                        set
                        {
                                this.@object = value;
                        }
                }

                private DateTime postTime;

                [Required]
                public DateTime PostTime
                {
                        get
                        {
                                return this.postTime;
                        }

                        set
                        {
                                this.postTime = value;
                        }
                }

                private string schema;

                public string Schema
                {
                        get
                        {
                                return this.schema.IsEmptyOrZeroOrNull() ? null : this.schema;
                        }

                        set
                        {
                                this.schema = value;
                        }
                }

                private string tSQL;

                [Required]
                public string TSQL
                {
                        get
                        {
                                return this.tSQL;
                        }

                        set
                        {
                                this.tSQL = value;
                        }
                }

                private string xmlEvent;

                [Required]
                public string XmlEvent
                {
                        get
                        {
                                return this.xmlEvent;
                        }

                        set
                        {
                                this.xmlEvent = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>7f95c6cc3845101112c05129163a69bc</Hash>
</Codenesium>*/