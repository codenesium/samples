using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("Sale", Schema="dbo")]
        public partial class Sale : AbstractEntity
        {
                public Sale()
                {
                }

                public virtual void SetProperties(
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
                public virtual Transaction TransactionNavigation { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1c59ce6ece9f57cad3ae8a0fe864ac66</Hash>
</Codenesium>*/