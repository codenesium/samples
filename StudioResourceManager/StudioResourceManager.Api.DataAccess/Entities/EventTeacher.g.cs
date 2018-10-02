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
			int id)
		{
			this.EventId = eventId;
			this.Id = id;
		}

		[Column("eventId")]
		public int EventId { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[ForeignKey("EventId")]
		public virtual Event EventNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b3f0daedc5ad7758def6c59c5d6ccbad</Hash>
</Codenesium>*/