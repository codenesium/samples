using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("TransactionHistoryArchive", Schema="Production")]
	public partial class EFTransactionHistoryArchive: AbstractEntityFrameworkPOCO
	{
		public EFTransactionHistoryArchive()
		{}

		public void SetProperties(
			int transactionID,
			int productID,
			int referenceOrderID,
			int referenceOrderLineID,
			DateTime transactionDate,
			string transactionType,
			int quantity,
			decimal actualCost,
			DateTime modifiedDate)
		{
			this.TransactionID = transactionID.ToInt();
			this.ProductID = productID.ToInt();
			this.ReferenceOrderID = referenceOrderID.ToInt();
			this.ReferenceOrderLineID = referenceOrderLineID.ToInt();
			this.TransactionDate = transactionDate.ToDateTime();
			this.TransactionType = transactionType.ToString();
			this.Quantity = quantity.ToInt();
			this.ActualCost = actualCost.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("TransactionID", TypeName="int")]
		public int TransactionID { get; set; }

		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("ReferenceOrderID", TypeName="int")]
		public int ReferenceOrderID { get; set; }

		[Column("ReferenceOrderLineID", TypeName="int")]
		public int ReferenceOrderLineID { get; set; }

		[Column("TransactionDate", TypeName="datetime")]
		public DateTime TransactionDate { get; set; }

		[Column("TransactionType", TypeName="nchar(1)")]
		public string TransactionType { get; set; }

		[Column("Quantity", TypeName="int")]
		public int Quantity { get; set; }

		[Column("ActualCost", TypeName="money")]
		public decimal ActualCost { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>f1a4876ffe9f3ce4cdb584309f069a72</Hash>
</Codenesium>*/