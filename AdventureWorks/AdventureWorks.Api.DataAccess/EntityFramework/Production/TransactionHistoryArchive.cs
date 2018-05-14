using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("TransactionHistoryArchive", Schema="Production")]
	public partial class TransactionHistoryArchive: AbstractEntityFrameworkPOCO
	{
		public TransactionHistoryArchive()
		{}

		public void SetProperties(
			int transactionID,
			decimal actualCost,
			DateTime modifiedDate,
			int productID,
			int quantity,
			int referenceOrderID,
			int referenceOrderLineID,
			DateTime transactionDate,
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
			this.TransactionType = transactionType.ToString();
		}

		[Column("ActualCost", TypeName="money")]
		public decimal ActualCost { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("Quantity", TypeName="int")]
		public int Quantity { get; set; }

		[Column("ReferenceOrderID", TypeName="int")]
		public int ReferenceOrderID { get; set; }

		[Column("ReferenceOrderLineID", TypeName="int")]
		public int ReferenceOrderLineID { get; set; }

		[Column("TransactionDate", TypeName="datetime")]
		public DateTime TransactionDate { get; set; }

		[Key]
		[Column("TransactionID", TypeName="int")]
		public int TransactionID { get; set; }

		[Column("TransactionType", TypeName="nchar(1)")]
		public string TransactionType { get; set; }
	}
}

/*<Codenesium>
    <Hash>4ddf1a4708cf08bc4fa6c835acb10697</Hash>
</Codenesium>*/