using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOTransactionHistory: AbstractBusinessObject
	{
		public BOTransactionHistory() : base()
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

		public decimal ActualCost { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int ProductID { get; private set; }
		public int Quantity { get; private set; }
		public int ReferenceOrderID { get; private set; }
		public int ReferenceOrderLineID { get; private set; }
		public DateTime TransactionDate { get; private set; }
		public int TransactionID { get; private set; }
		public string TransactionType { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ed0e673f3070e0722d44b358732a1df0</Hash>
</Codenesium>*/