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
			int id,
			int eventId,
			int teacherId)
		{
			this.Id = id;
			this.EventId = eventId;
			this.TeacherId = teacherId;
		}

		[Column("eventId")]
		public virtual int EventId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("teacherId")]
		public virtual int TeacherId { get; private set; }

		[ForeignKey("Id")]
		public virtual Event IdNavigation { get; private set; }

		public void SetIdNavigation(Event item)
		{
			this.IdNavigation = item;
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
    <Hash>8367cb9aa9707ab3700066f67804279d</Hash>
</Codenesium>*/