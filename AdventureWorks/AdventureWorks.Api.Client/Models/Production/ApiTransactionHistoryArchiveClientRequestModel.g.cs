using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiTransactionHistoryArchiveClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiTransactionHistoryArchiveClientRequestModel()
			: base()
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
			string transactionType)
		{
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
		public decimal ActualCost { get; private set; } = default(decimal);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int ProductID { get; private set; } = default(int);

		[JsonProperty]
		public int Quantity { get; private set; } = default(int);

		[JsonProperty]
		public int ReferenceOrderID { get; private set; } = default(int);

		[JsonProperty]
		public int ReferenceOrderLineID { get; private set; } = default(int);

		[JsonProperty]
		public DateTime TransactionDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string TransactionType { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>edeac8a0649a2d06af9599365524c3ad</Hash>
</Codenesium>*/