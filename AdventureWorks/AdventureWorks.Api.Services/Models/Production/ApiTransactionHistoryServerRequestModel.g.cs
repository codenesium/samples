using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiTransactionHistoryServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiTransactionHistoryServerRequestModel()
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

		[Required]
		[JsonProperty]
		public decimal ActualCost { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public int ProductID { get; private set; }

		[Required]
		[JsonProperty]
		public int Quantity { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int ReferenceOrderID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int ReferenceOrderLineID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public DateTime TransactionDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string TransactionType { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>aab00d740aa023f020899b193eb31fc2</Hash>
</Codenesium>*/