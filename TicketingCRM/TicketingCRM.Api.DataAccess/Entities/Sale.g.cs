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
			string note,
			DateTime saleDate,
			int transactionId)
		{
			this.Id = id;
			this.IpAddress = ipAddress;
			this.Note = note;
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
		public virtual string Note { get; private set; }

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
    <Hash>0de8c32c1ca14d616cdad613cef3924f</Hash>
</Codenesium>*/