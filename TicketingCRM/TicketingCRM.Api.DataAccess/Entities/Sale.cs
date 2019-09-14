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
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("ipAddress")]
		public virtual string IpAddress { get; private set; }

		[MaxLength(2147483647)]
		[Column("notes")]
		public virtual string Notes { get; private set; }

		[Column("saleDate")]
		public virtual DateTime SaleDate { get; private set; }

		[Column("transactionId")]
		public virtual int TransactionId { get; private set; }

		[ForeignKey("TransactionId")]
		public virtual Transaction TransactionIdNavigation { get; private set; }

		public void SetTransactionIdNavigation(Transaction item)
		{
			this.TransactionIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>589b4322f44bc9718505c3e72f1a4d5c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/