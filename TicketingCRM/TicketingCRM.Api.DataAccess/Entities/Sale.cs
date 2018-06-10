using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("Sale", Schema="dbo")]
        public partial class Sale:AbstractEntity
        {
                public Sale()
                {
                }

                public void SetProperties(
                        int id,
                        string ipAddress,
                        string notes,
                        DateTime saleDate,
                        int transactionId)
                {
                        this.Id = id;
                        this.IpAddress = ipAddress;
                        this.Notes = notes;
                        this.SaleDate = saleDate;
                        this.TransactionId = transactionId;
                }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("ipAddress", TypeName="varchar(128)")]
                public string IpAddress { get; private set; }

                [Column("notes", TypeName="text(2147483647)")]
                public string Notes { get; private set; }

                [Column("saleDate", TypeName="datetime")]
                public DateTime SaleDate { get; private set; }

                [Column("transactionId", TypeName="int")]
                public int TransactionId { get; private set; }

                [ForeignKey("TransactionId")]
                public virtual Transaction Transaction { get; set; }
        }
}

/*<Codenesium>
    <Hash>3d8ecfc01cd78c9a043ad31fbffd6ae5</Hash>
</Codenesium>*/