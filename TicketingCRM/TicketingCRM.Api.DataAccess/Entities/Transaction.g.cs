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
			int id,
			decimal amount,
			string gatewayConfirmationNumber,
			int transactionStatusId)
		{
			this.Id = id;
			this.Amount = amount;
			this.GatewayConfirmationNumber = gatewayConfirmationNumber;
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
		public virtual TransactionStatu TransactionStatusIdNavigation { get; private set; }

		public void SetTransactionStatusIdNavigation(TransactionStatu item)
		{
			this.TransactionStatusIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>dafd8631a99f35fb1b266e999dcc7356</Hash>
</Codenesium>*/