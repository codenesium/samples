using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("Ticket", Schema="dbo")]
        public partial class Ticket : AbstractEntity
        {
                public Ticket()
                {
                }

                public void SetProperties(
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
                public virtual TicketStatus TicketStatus { get; set; }
        }
}

/*<Codenesium>
    <Hash>a7eee8a4946a055689b9ff4895d15d61</Hash>
</Codenesium>*/