using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiTransactionHistoryClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
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
			this.TransactionID = transactionID;
			this.ActualCost = actualCost;
			this.ModifiedDate = modifiedDate;
			this.ProductID = productID;
			this.Quantity = quantity;
			this.ReferenceOrderID = referenceOrderID;
			this.ReferenceOrderLineID = referenceOrderLineID;
			this.TransactionDate = transactionDate;
			this.TransactionType = transactionType;
		}

		[JsonProperty]
		public decimal ActualCost { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int ProductID { get; private set; }

		[JsonProperty]
		public int Quantity { get; private set; }

		[JsonProperty]
		public int ReferenceOrderID { get; private set; }

		[JsonProperty]
		public int ReferenceOrderLineID { get; private set; }

		[JsonProperty]
		public DateTime TransactionDate { get; private set; }

		[JsonProperty]
		public int TransactionID { get; private set; }

		[JsonProperty]
		public string TransactionType { get; private set; }
	}
}

/*<Codenesium>
    <Hash>965908543a2624a9ea636f9bc5ff026d</Hash>
</Codenesium>*/