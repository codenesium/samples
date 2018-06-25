using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

                [Column("EventId")]
                public string EventId { get; private set; }

                [Key]
                [Column("Id")]
                public int Id { get; private set; }

                [Column("RelatedDocumentId")]
                public string RelatedDocumentId { get; private set; }

                [ForeignKey("EventId")]
                public virtual Event Event { get; set; }
        }
}

/*<Codenesium>
    <Hash>73fbc5ebb954cddbc46abdd37f06080a</Hash>
</Codenesium>*/