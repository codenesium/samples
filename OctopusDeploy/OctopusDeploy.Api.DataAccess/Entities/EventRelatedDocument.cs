using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("EventRelatedDocument", Schema="dbo")]
        public partial class EventRelatedDocument: AbstractEntity
        {
                public EventRelatedDocument()
                {
                }

                public void SetProperties(
                        string eventId,
                        int id,
                        string relatedDocumentId)
                {
                        this.EventId = eventId;
                        this.Id = id;
                        this.RelatedDocumentId = relatedDocumentId;
                }

                [Column("EventId", TypeName="nvarchar(50)")]
                public string EventId { get; private set; }

                [Key]
                [Column("Id", TypeName="int")]
                public int Id { get; private set; }

                [Column("RelatedDocumentId", TypeName="nvarchar(250)")]
                public string RelatedDocumentId { get; private set; }

                [ForeignKey("EventId")]
                public virtual Event Event { get; set; }
        }
}

/*<Codenesium>
    <Hash>07af7d001d9d52c86e1e13d4a8a4481f</Hash>
</Codenesium>*/