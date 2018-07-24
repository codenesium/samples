using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("Ticket", Schema="dbo")]
        public partial class Ticket : AbstractEntity
        {
                public Ticket()
                {
                }

                public virtual void SetProperties(
                        int id,
                        string publicId,
                        int ticketStatusId)
                {
                        this.Id = id;
                        this.PublicId = publicId;
                        this.TicketStatusId = ticketStatusId;
                }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("publicId")]
                public string PublicId { get; private set; }

                [Column("ticketStatusId")]
                public int TicketStatusId { get; private set; }

                [ForeignKey("TicketStatusId")]
                public virtual TicketStatus TicketStatusNavigation { get; private set; }
        }
}

/*<Codenesium>
    <Hash>4ad91549e0d90f4d009f120290273861</Hash>
</Codenesium>*/