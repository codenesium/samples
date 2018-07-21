using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("DatabaseLog", Schema="dbo")]
        public partial class DatabaseLog : AbstractEntity
        {
                public DatabaseLog()
                {
                }

                public virtual void SetProperties(
                        int databaseLogID,
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

                [Key]
                [Column("DatabaseLogID")]
                public int DatabaseLogID { get; private set; }

                [Column("DatabaseUser")]
                public string DatabaseUser { get; private set; }

                [Column("Event")]
                public string @Event { get; private set; }

                [Column("Object")]
                public string @Object { get; private set; }

                [Column("PostTime")]
                public DateTime PostTime { get; private set; }

                [Column("Schema")]
                public string Schema { get; private set; }

                [Column("TSQL")]
                public string Tsql { get; private set; }

                [Column("XmlEvent")]
                public string XmlEvent { get; private set; }
        }
}

/*<Codenesium>
    <Hash>4459be30b16c6b1ae8d830b6a2f45334</Hash>
</Codenesium>*/