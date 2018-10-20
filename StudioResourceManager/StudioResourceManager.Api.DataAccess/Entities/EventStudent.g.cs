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
			int studentId,
			bool isDeleted)
		{
			this.EventId = eventId;
			this.StudentId = studentId;
			this.IsDeleted = isDeleted;
		}

		[Key]
		[Column("eventId")]
		public int EventId { get; private set; }

		[Key]
		[Column("studentId")]
		public int StudentId { get; private set; }

		[Column("isDeleted")]
		public bool IsDeleted { get; private set; }

		[ForeignKey("EventId")]
		public virtual Event EventNavigation { get; private set; }

		[ForeignKey("StudentId")]
		public virtual Student StudentNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>47da64e2346abd8154b2e46c0bea4d4a</Hash>
</Codenesium>*/