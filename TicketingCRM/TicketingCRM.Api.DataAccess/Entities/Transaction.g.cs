using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
		public virtual decimal Amount { get; private set; }

		[MaxLength(1)]
		[Column("gatewayConfirmationNumber")]
		public virtual string GatewayConfirmationNumber { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("transactionStatusId")]
		public virtual int TransactionStatusId { get; private set; }

		[ForeignKey("TransactionStatusId")]
		public virtual TransactionStatu TransactionStatuNavigation { get; private set; }

		public void SetTransactionStatuNavigation(TransactionStatu item)
		{
			this.TransactionStatuNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>d44138a08340fe36f48eeb28ab8fd705</Hash>
</Codenesium>*/