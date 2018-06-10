using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("SaleTickets", Schema="dbo")]
        public partial class SaleTickets: AbstractEntity
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
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("saleId", TypeName="int")]
                public int SaleId { get; private set; }

                [Column("ticketId", TypeName="int")]
                public int TicketId { get; private set; }

                [ForeignKey("SaleId")]
                public virtual Sale Sale { get; set; }

                [ForeignKey("TicketId")]
                public virtual Ticket Ticket { get; set; }
        }
}

/*<Codenesium>
    <Hash>7cb7d1d94f1fd16a69383563fa45c4bc</Hash>
</Codenesium>*/