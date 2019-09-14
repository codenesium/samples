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
		public virtual TransactionStatus TransactionStatusIdNavigation { get; private set; }

		public void SetTransactionStatusIdNavigation(TransactionStatus item)
		{
			this.TransactionStatusIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>670bc6c6d7ae418915d527806ab3851a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/