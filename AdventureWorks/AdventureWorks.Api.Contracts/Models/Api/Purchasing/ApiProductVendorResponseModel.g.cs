using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductVendorResponseModel: AbstractApiResponseModel
	{
		public ApiProductVendorResponseModel() : base()
		{}

		public void SetProperties(
			int averageLeadTime,
			int businessEntityID,
			Nullable<decimal> lastReceiptCost,
			Nullable<DateTime> lastReceiptDate,
			int maxOrderQty,
			int minOrderQty,
			DateTime modifiedDate,
			Nullable<int> onOrderQty,
			int productID,
			decimal standardPrice,
			string unitMeasureCode)
		{
			this.AverageLeadTime = averageLeadTime.ToInt();
			this.BusinessEntityID = businessEntityID.ToInt();
			this.LastReceiptCost = lastReceiptCost.ToNullableDecimal();
			this.LastReceiptDate = lastReceiptDate.ToNullableDateTime();
			this.MaxOrderQty = maxOrderQty.ToInt();
			this.MinOrderQty = minOrderQty.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.OnOrderQty = onOrderQty.ToNullableInt();
			this.ProductID = productID.ToInt();
			this.StandardPrice = standardPrice.ToDecimal();
			this.UnitMeasureCode = unitMeasureCode;
		}

		public int AverageLeadTime { get; private set; }
		public int BusinessEntityID { get; private set; }
		public Nullable<decimal> LastReceiptCost { get; private set; }
		public Nullable<DateTime> LastReceiptDate { get; private set; }
		public int MaxOrderQty { get; private set; }
		public int MinOrderQty { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public Nullable<int> OnOrderQty { get; private set; }
		public int ProductID { get; private set; }
		public decimal StandardPrice { get; private set; }
		public string UnitMeasureCode { get; private set; }

		[JsonIgnore]
		public bool ShouldSerializeAverageLeadTimeValue { get; set; } = true;

		public bool ShouldSerializeAverageLeadTime()
		{
			return this.ShouldSerializeAverageLeadTimeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLastReceiptCostValue { get; set; } = true;

		public bool ShouldSerializeLastReceiptCost()
		{
			return this.ShouldSerializeLastReceiptCostValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLastReceiptDateValue { get; set; } = true;

		public bool ShouldSerializeLastReceiptDate()
		{
			return this.ShouldSerializeLastReceiptDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeMaxOrderQtyValue { get; set; } = true;

		public bool ShouldSerializeMaxOrderQty()
		{
			return this.ShouldSerializeMaxOrderQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeMinOrderQtyValue { get; set; } = true;

		public bool ShouldSerializeMinOrderQty()
		{
			return this.ShouldSerializeMinOrderQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOnOrderQtyValue { get; set; } = true;

		public bool ShouldSerializeOnOrderQty()
		{
			return this.ShouldSerializeOnOrderQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStandardPriceValue { get; set; } = true;

		public bool ShouldSerializeStandardPrice()
		{
			return this.ShouldSerializeStandardPriceValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeUnitMeasureCodeValue { get; set; } = true;

		public bool ShouldSerializeUnitMeasureCode()
		{
			return this.ShouldSerializeUnitMeasureCodeValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAverageLeadTimeValue = false;
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeLastReceiptCostValue = false;
			this.ShouldSerializeLastReceiptDateValue = false;
			this.ShouldSerializeMaxOrderQtyValue = false;
			this.ShouldSerializeMinOrderQtyValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeOnOrderQtyValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeStandardPriceValue = false;
			this.ShouldSerializeUnitMeasureCodeValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>02eb97918dd9aa0b79cb2fe51668540d</Hash>
</Codenesium>*/