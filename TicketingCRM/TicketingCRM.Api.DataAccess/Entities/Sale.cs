using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("Sale", Schema="dbo")]
        public partial class Sale : AbstractEntity
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
                [Column("id")]
                public int Id { get; private set; }

                [Column("ipAddress")]
                public string IpAddress { get; private set; }

                [Column("notes")]
                public string Notes { get; private set; }

                [Column("saleDate")]
                public DateTime SaleDate { get; private set; }

                [Column("transactionId")]
                public int TransactionId { get; private set; }

                [ForeignKey("TransactionId")]
                public virtual Transaction Transaction { get; set; }
        }
}

/*<Codenesium>
    <Hash>57101a0dfdcd76b4a7654c745ec16322</Hash>
</Codenesium>*/