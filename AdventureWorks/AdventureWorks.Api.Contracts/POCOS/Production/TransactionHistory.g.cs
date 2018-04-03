using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOTransactionHistory
	{
		public POCOTransactionHistory()
		{}

		public POCOTransactionHistory(int transactionID,
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

		public int TransactionID {get; set;}
		public int ProductID {get; set;}
		public int ReferenceOrderID {get; set;}
		public int ReferenceOrderLineID {get; set;}
		public DateTime TransactionDate {get; set;}
		public string TransactionType {get; set;}
		public int Quantity {get; set;}
		public decimal ActualCost {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeTransactionIDValue {get; set;} = true;

		public bool ShouldSerializeTransactionID()
		{
			return ShouldSerializeTransactionIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue {get; set;} = true;

		public bool ShouldSerializeProductID()
		{
			return ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeReferenceOrderIDValue {get; set;} = true;

		public bool ShouldSerializeReferenceOrderID()
		{
			return ShouldSerializeReferenceOrderIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeReferenceOrderLineIDValue {get; set;} = true;

		public bool ShouldSerializeReferenceOrderLineID()
		{
			return ShouldSerializeReferenceOrderLineIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTransactionDateValue {get; set;} = true;

		public bool ShouldSerializeTransactionDate()
		{
			return ShouldSerializeTransactionDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTransactionTypeValue {get; set;} = true;

		public bool ShouldSerializeTransactionType()
		{
			return ShouldSerializeTransactionTypeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeQuantityValue {get; set;} = true;

		public bool ShouldSerializeQuantity()
		{
			return ShouldSerializeQuantityValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeActualCostValue {get; set;} = true;

		public bool ShouldSerializeActualCost()
		{
			return ShouldSerializeActualCostValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeTransactionIDValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeReferenceOrderIDValue = false;
			this.ShouldSerializeReferenceOrderLineIDValue = false;
			this.ShouldSerializeTransactionDateValue = false;
			this.ShouldSerializeTransactionTypeValue = false;
			this.ShouldSerializeQuantityValue = false;
			this.ShouldSerializeActualCostValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>b1b34c1a80934c7cdbeb5db0161ddabf</Hash>
</Codenesium>*/