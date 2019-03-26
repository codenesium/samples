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
			DateTime postTime,
			string reservedEvent,
			string reservedObject,
			string schema,
			string tsql,
			string xmlEvent)
		{
			this.DatabaseLogID = databaseLogID;
			this.DatabaseUser = databaseUser;
			this.PostTime = postTime;
			this.ReservedEvent = reservedEvent;
			this.ReservedObject = reservedObject;
			this.Schema = schema;
			this.Tsql = tsql;
			this.XmlEvent = xmlEvent;
		}

		[Key]
		[Column("DatabaseLogID")]
		public virtual int DatabaseLogID { get; private set; }

		[MaxLength(128)]
		[Column("DatabaseUser")]
		public virtual string DatabaseUser { get; private set; }

		[MaxLength(128)]
		[Column("Event")]
		public virtual string ReservedEvent { get; private set; }

		[MaxLength(128)]
		[Column("Object")]
		public virtual string ReservedObject { get; private set; }

		[Column("PostTime")]
		public virtual DateTime PostTime { get; private set; }

		[MaxLength(128)]
		[Column("Schema")]
		public virtual string Schema { get; private set; }

		[Column("TSQL")]
		public virtual string Tsql { get; private set; }

		[Column("XmlEvent")]
		public virtual string XmlEvent { get; private set; }
	}
}

/*<Codenesium>
    <Hash>41658c0cb19ce2d7d99003b2eeec51c1</Hash>
</Codenesium>*/