using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("EventRelatedDocument", Schema="dbo")]
	public partial class EventRelatedDocument : AbstractEntity
	{
		public EventRelatedDocument()
		{
		}

		public virtual void SetProperties(
			string eventId,
			int id,
			string relatedDocumentId)
		{
			this.EventId = eventId;
			this.Id = id;
			this.RelatedDocumentId = relatedDocumentId;
		}

		[MaxLength(50)]
		[Column("EventId")]
		public string EventId { get; private set; }

		[Key]
		[Column("Id")]
		public int Id { get; private set; }

		[MaxLength(250)]
		[Column("RelatedDocumentId")]
		public string RelatedDocumentId { get; private set; }

		[ForeignKey("EventId")]
		public virtual Event EventNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a20ce8f19cbb574542b30d6c39f565cd</Hash>
</Codenesium>*/