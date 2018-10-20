using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerNS.Api.DataAccess
{
	[Table("EventTeacher", Schema="dbo")]
	public partial class EventTeacher : AbstractEntity
	{
		public EventTeacher()
		{
		}

		public virtual void SetProperties(
			int eventId,
			int teacherId,
			bool isDeleted)
		{
			this.EventId = eventId;
			this.TeacherId = teacherId;
			this.IsDeleted = isDeleted;
		}

		[Key]
		[Column("eventId")]
		public int EventId { get; private set; }

		[Key]
		[Column("teacherId")]
		public int TeacherId { get; private set; }

		[Column("isDeleted")]
		public bool IsDeleted { get; private set; }

		[ForeignKey("EventId")]
		public virtual Event EventNavigation { get; private set; }

		[ForeignKey("TeacherId")]
		public virtual Teacher TeacherNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a3bcc2ca2b41a8205d1acab920a4610a</Hash>
</Codenesium>*/