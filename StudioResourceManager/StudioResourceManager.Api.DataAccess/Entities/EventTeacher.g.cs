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
		public virtual int EventId { get; private set; }

		[Key]
		[Column("teacherId")]
		public virtual int TeacherId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>690cc5d7f57495c378d9019b1eddb13b</Hash>
</Codenesium>*/