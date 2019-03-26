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
			int id,
			int eventId,
			int studentId)
		{
			this.Id = id;
			this.EventId = eventId;
			this.StudentId = studentId;
		}

		[Column("eventId")]
		public virtual int EventId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

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
    <Hash>aa642928354e7aec5d724dd62a29a7e5</Hash>
</Codenesium>*/