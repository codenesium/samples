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
		public int EventId { get; private set; }

		[Key]
		[Column("studentId")]
		public int StudentId { get; private set; }

		[ForeignKey("EventId")]
		public virtual Event EventNavigation { get; private set; }

		[ForeignKey("StudentId")]
		public virtual Student StudentNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>db77da1bc29a08247ca8028a3d6002d3</Hash>
</Codenesium>*/