using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("Ticket", Schema="dbo")]
        public partial class Ticket:AbstractEntity
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
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("publicId", TypeName="varchar(8)")]
                public string PublicId { get; private set; }

                [Column("ticketStatusId", TypeName="int")]
                public int TicketStatusId { get; private set; }

                [ForeignKey("TicketStatusId")]
                public virtual TicketStatus TicketStatus { get; set; }
        }
}

/*<Codenesium>
    <Hash>995d0fbdee0db0da64f96ad8d8749b82</Hash>
</Codenesium>*/