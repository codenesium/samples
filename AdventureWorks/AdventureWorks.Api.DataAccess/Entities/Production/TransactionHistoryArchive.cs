using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("TransactionHistoryArchive", Schema="Production")]
	public partial class TransactionHistoryArchive: AbstractEntity
	{
		public TransactionHistoryArchive()
		{}

		public void SetProperties(
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
			this.ActualCost = actualCost.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
			this.Quantity = quantity.ToInt();
			this.ReferenceOrderID = referenceOrderID.ToInt();
			this.ReferenceOrderLineID = referenceOrderLineID.ToInt();
			this.TransactionDate = transactionDate.ToDateTime();
			this.TransactionID = transactionID.ToInt();
			this.TransactionType = transactionType;
		}

		[Column("ActualCost", TypeName="money")]
		public decimal ActualCost { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("ProductID", TypeName="int")]
		public int ProductID { get; private set; }

		[Column("Quantity", TypeName="int")]
		public int Quantity { get; private set; }

		[Column("ReferenceOrderID", TypeName="int")]
		public int ReferenceOrderID { get; private set; }

		[Column("ReferenceOrderLineID", TypeName="int")]
		public int ReferenceOrderLineID { get; private set; }

		[Column("TransactionDate", TypeName="datetime")]
		public DateTime TransactionDate { get; private set; }

		[Key]
		[Column("TransactionID", TypeName="int")]
		public int TransactionID { get; private set; }

		[Column("TransactionType", TypeName="nchar(1)")]
		public string TransactionType { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6c9ac01247f042d8e8c61eaf7951c4b1</Hash>
</Codenesium>*/