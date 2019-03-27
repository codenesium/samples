using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerMTNS.Api.DataAccess
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
		public virtual int EventId { get; private set; }

		[Key]
		[Column("teacherId")]
		public virtual int TeacherId { get; private set; }

		[ForeignKey("EventId")]
		public virtual Event EventIdNavigation { get; private set; }

		public void SetEventIdNavigation(Event item)
		{
			this.EventIdNavigation = item;
		}

		[ForeignKey("TeacherId")]
		public virtual Teacher TeacherIdNavigation { get; private set; }

		public void SetTeacherIdNavigation(Teacher item)
		{
			this.TeacherIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>ea4066de9124a13e246585e10bfb48b0</Hash>
</Codenesium>*/