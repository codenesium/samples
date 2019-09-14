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
    <Hash>ed46cdecb67caf664feab4c26ec9cffb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/