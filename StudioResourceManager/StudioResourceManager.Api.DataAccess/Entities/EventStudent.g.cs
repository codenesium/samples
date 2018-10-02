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
			int id,
			int studentId)
		{
			this.EventId = eventId;
			this.Id = id;
			this.StudentId = studentId;
		}

		[Column("eventId")]
		public int EventId { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[Column("studentId")]
		public int StudentId { get; private set; }

		[ForeignKey("EventId")]
		public virtual Event EventNavigation { get; private set; }

		[ForeignKey("StudentId")]
		public virtual Student StudentNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d379d3ba5bc6d53820fab70c990f5d9f</Hash>
</Codenesium>*/