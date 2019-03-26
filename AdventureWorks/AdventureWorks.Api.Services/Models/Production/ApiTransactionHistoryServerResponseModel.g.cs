using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiTransactionHistoryServerResponseModel : AbstractApiServerResponseModel
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
		public string ProductIDEntity { get; private set; } = RouteConstants.Products;

		[JsonProperty]
		public ApiProductServerResponseModel ProductIDNavigation { get; private set; }

		public void SetProductIDNavigation(ApiProductServerResponseModel value)
		{
			this.ProductIDNavigation = value;
		}

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
    <Hash>441a9e6e0b6f84574287ea8474979993</Hash>
</Codenesium>*/