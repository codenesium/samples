using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiTransactionHistoryArchiveResponseModel: AbstractApiResponseModel
	{
		public ApiTransactionHistoryArchiveResponseModel() : base()
		{}

		public void SetProperties(
			decimal actualCost,
			DateTime modifiedDate,
			int productID,
			int quantity,
			int referenceOrderID,
			int referenceOrderLineID,
			DateTime transactionDate,
			int transactionID,
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

		[JsonIgnore]
		public bool ShouldSerializeActualCostValue { get; set; } = true;

		public bool ShouldSerializeActualCost()
		{
			return this.ShouldSerializeActualCostValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeQuantityValue { get; set; } = true;

		public bool ShouldSerializeQuantity()
		{
			return this.ShouldSerializeQuantityValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeReferenceOrderIDValue { get; set; } = true;

		public bool ShouldSerializeReferenceOrderID()
		{
			return this.ShouldSerializeReferenceOrderIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeReferenceOrderLineIDValue { get; set; } = true;

		public bool ShouldSerializeReferenceOrderLineID()
		{
			return this.ShouldSerializeReferenceOrderLineIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTransactionDateValue { get; set; } = true;

		public bool ShouldSerializeTransactionDate()
		{
			return this.ShouldSerializeTransactionDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTransactionIDValue { get; set; } = true;

		public bool ShouldSerializeTransactionID()
		{
			return this.ShouldSerializeTransactionIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTransactionTypeValue { get; set; } = true;

		public bool ShouldSerializeTransactionType()
		{
			return this.ShouldSerializeTransactionTypeValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeActualCostValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeQuantityValue = false;
			this.ShouldSerializeReferenceOrderIDValue = false;
			this.ShouldSerializeReferenceOrderLineIDValue = false;
			this.ShouldSerializeTransactionDateValue = false;
			this.ShouldSerializeTransactionIDValue = false;
			this.ShouldSerializeTransactionTypeValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>e63ad65cf7e1991ad2130a79af623039</Hash>
</Codenesium>*/