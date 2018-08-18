using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOTransactionHistory : AbstractBusinessObject
	{
		public AbstractBOTransactionHistory()
			: base()
		{
		}

		public virtual void SetProperties(int transactionID,
		                                  decimal actualCost,
		                                  DateTime modifiedDate,
		                                  int productID,
		                                  int quantity,
		                                  int referenceOrderID,
		                                  int referenceOrderLineID,
		                                  DateTime transactionDate,
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
    <Hash>08dbba6cd6662f50e7b91521fb1dc848</Hash>
</Codenesium>*/