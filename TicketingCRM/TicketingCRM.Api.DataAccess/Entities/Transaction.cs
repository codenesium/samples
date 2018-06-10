using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("Transaction", Schema="dbo")]
        public partial class Transaction: AbstractEntity
        {
                public Transaction()
                {
                }

                public void SetProperties(
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

                [Column("amount", TypeName="money")]
                public decimal Amount { get; private set; }

                [Column("gatewayConfirmationNumber", TypeName="varchar(1)")]
                public string GatewayConfirmationNumber { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("transactionStatusId", TypeName="int")]
                public int TransactionStatusId { get; private set; }

                [ForeignKey("TransactionStatusId")]
                public virtual TransactionStatus TransactionStatus { get; set; }
        }
}

/*<Codenesium>
    <Hash>b21d037600ce2a091c1be4359302cabb</Hash>
</Codenesium>*/