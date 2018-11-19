using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerNS.Api.DataAccess
{
	[Table("EventStudent", Schema="dbo")]
	public partial class EventStudent : AbstractEntity
	{
		public EventStudent()
		{
		}

		public virtual void SetProperties(
			int eventId,
			int studentId)
		{
			this.EventId = eventId;
			this.StudentId = studentId;
		}

		[Key]
		[Column("eventId")]
		public virtual int EventId { get; private set; }

		[Key]
		[Column("studentId")]
		public virtual int StudentId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>dfb8d349c77c907199437c9fc4f386eb</Hash>
</Codenesium>*/