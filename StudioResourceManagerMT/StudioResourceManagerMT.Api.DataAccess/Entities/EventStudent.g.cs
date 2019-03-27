using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerMTNS.Api.DataAccess
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

		[ForeignKey("EventId")]
		public virtual Event EventIdNavigation { get; private set; }

		public void SetEventIdNavigation(Event item)
		{
			this.EventIdNavigation = item;
		}

		[ForeignKey("StudentId")]
		public virtual Student StudentIdNavigation { get; private set; }

		public void SetStudentIdNavigation(Student item)
		{
			this.StudentIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>54c567509fd69ae161cd4cb554db4abf</Hash>
</Codenesium>*/