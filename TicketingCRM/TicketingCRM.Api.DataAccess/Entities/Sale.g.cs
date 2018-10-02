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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(128)]
		[Column("ipAddress")]
		public string IpAddress { get; private set; }

		[MaxLength(2147483647)]
		[Column("notes")]
		public string Note { get; private set; }

		[Column("saleDate")]
		public DateTime SaleDate { get; private set; }

		[Column("transactionId")]
		public int TransactionId { get; private set; }

		[ForeignKey("TransactionId")]
		public virtual Transaction TransactionNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>809cbd7e59db011c17aebc66c00163b1</Hash>
</Codenesium>*/