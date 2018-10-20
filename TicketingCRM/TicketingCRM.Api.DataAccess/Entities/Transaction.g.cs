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
		public decimal Amount { get; private set; }

		[MaxLength(1)]
		[Column("gatewayConfirmationNumber")]
		public string GatewayConfirmationNumber { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[Column("transactionStatusId")]
		public int TransactionStatusId { get; private set; }

		[ForeignKey("TransactionStatusId")]
		public virtual TransactionStatu TransactionStatuNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a7a4b8cd2808adad53c30414cfe6afc1</Hash>
</Codenesium>*/