using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.Contracts
{
	[Table("TransactionHistoryArchive", Schema="Production")]
	public partial class EFTransactionHistoryArchive
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
			this.TransactionType = transactionType;
			this.Quantity = quantity.ToInt();
			this.ActualCost = actualCost;
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
    <Hash>0d8723b203ee5ae07fbfee35ee70347b</Hash>
</Codenesium>*/