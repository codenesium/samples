using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("Transaction", Schema="dbo")]
        public partial class Transaction : AbstractEntity
        {
                public Transaction()
                {
                }

                public virtual void SetProperties(
                        decimal amount,
                        string gatewayConfirmationNumber,
                        int id,
                        int transactionStatusId)
                {
                        this.Amount = amount;
                        this.GatewayConfirmationNumber = gatewayConfirmationNumber;
                        this.Id = id;
                        this.TransactionStatusId = transactionStatusId;
                }

                [Column("amount")]
                public decimal Amount { get; private set; }

                [Column("gatewayConfirmationNumber")]
                public string GatewayConfirmationNumber { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("transactionStatusId")]
                public int TransactionStatusId { get; private set; }

                [ForeignKey("TransactionStatusId")]
                public virtual TransactionStatus TransactionStatus { get; set; }
        }
}

/*<Codenesium>
    <Hash>7704b90d9cf849998d68d95e8964e313</Hash>
</Codenesium>*/