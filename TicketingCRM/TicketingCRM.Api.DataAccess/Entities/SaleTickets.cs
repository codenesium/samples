using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("SaleTickets", Schema="dbo")]
        public partial class SaleTickets : AbstractEntity
        {
                public SaleTickets()
                {
                }

                public void SetProperties(
                        int id,
                        int saleId,
                        int ticketId)
                {
                        this.Id = id;
                        this.SaleId = saleId;
                        this.TicketId = ticketId;
                }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("saleId")]
                public int SaleId { get; private set; }

                [Column("ticketId")]
                public int TicketId { get; private set; }

                [ForeignKey("SaleId")]
                public virtual Sale Sale { get; set; }

                [ForeignKey("TicketId")]
                public virtual Ticket Ticket { get; set; }
        }
}

/*<Codenesium>
    <Hash>d9732e58b068a907205111bc1798b5bb</Hash>
</Codenesium>*/