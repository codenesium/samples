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
			int teacherId)
		{
			this.EventId = eventId;
			this.TeacherId = teacherId;
		}

		[Key]
		[Column("eventId")]
		public int EventId { get; private set; }

		[Key]
		[Column("teacherId")]
		public int TeacherId { get; private set; }

		[ForeignKey("EventId")]
		public virtual Event EventNavigation { get; private set; }

		[ForeignKey("TeacherId")]
		public virtual Teacher TeacherNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c2e947df11cfc64bb25d95a7c6cafaa6</Hash>
</Codenesium>*/