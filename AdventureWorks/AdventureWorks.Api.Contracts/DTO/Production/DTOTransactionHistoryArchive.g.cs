using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOTransactionHistoryArchive: AbstractDTO
	{
		public DTOTransactionHistoryArchive() : base()
		{}

		public void SetProperties(int transactionID,
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
			this.TransactionType = transactionType;
		}

		public decimal ActualCost { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ProductID { get; set; }
		public int Quantity { get; set; }
		public int ReferenceOrderID { get; set; }
		public int ReferenceOrderLineID { get; set; }
		public DateTime TransactionDate { get; set; }
		public int TransactionID { get; set; }
		public string TransactionType { get; set; }
	}
}

/*<Codenesium>
    <Hash>4dda3df498fccc17605d6f79227b4939</Hash>
</Codenesium>*/