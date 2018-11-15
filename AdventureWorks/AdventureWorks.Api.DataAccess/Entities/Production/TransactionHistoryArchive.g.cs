using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("TransactionHistoryArchive", Schema="Production")]
	public partial class TransactionHistoryArchive : AbstractEntity
	{
		public TransactionHistoryArchive()
		{
		}

		public virtual void SetProperties(
			decimal actualCost,
			DateTime modifiedDate,
			int productID,
			int quantity,
			int referenceOrderID,
			int referenceOrderLineID,
			DateTime transactionDate,
			int transactionID,
			string transactionType)
		{
			this.ActualCost = actualCost;
			this.ModifiedDate = modifiedDate;
			this.ProductID = productID;
			this.Quantity = quantity;
			this.ReferenceOrderID = referenceOrderID;
			this.ReferenceOrderLineID = referenceOrderLineID;
			this.TransactionDate = transactionDate;
			this.TransactionID = transactionID;
			this.TransactionType = transactionType;
		}

		[Column("ActualCost")]
		public virtual decimal ActualCost { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("ProductID")]
		public virtual int ProductID { get; private set; }

		[Column("Quantity")]
		public virtual int Quantity { get; private set; }

		[Column("ReferenceOrderID")]
		public virtual int ReferenceOrderID { get; private set; }

		[Column("ReferenceOrderLineID")]
		public virtual int ReferenceOrderLineID { get; private set; }

		[Column("TransactionDate")]
		public virtual DateTime TransactionDate { get; private set; }

		[Key]
		[Column("TransactionID")]
		public virtual int TransactionID { get; private set; }

		[MaxLength(1)]
		[Column("TransactionType")]
		public virtual string TransactionType { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e9a078cdd67e5c5e0d518274103e6c42</Hash>
</Codenesium>*/