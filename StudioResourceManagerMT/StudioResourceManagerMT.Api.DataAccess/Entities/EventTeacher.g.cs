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
	}
}

/*<Codenesium>
    <Hash>f6a164a8729b4a3d79d88aca3cf811b1</Hash>
</Codenesium>*/