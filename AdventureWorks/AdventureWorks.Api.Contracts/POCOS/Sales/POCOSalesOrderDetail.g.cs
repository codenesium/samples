using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOSalesOrderDetail
	{
		public POCOSalesOrderDetail()
		{}

		public POCOSalesOrderDetail(
			int salesOrderID,
			int salesOrderDetailID,
			string carrierTrackingNumber,
			short orderQty,
			int productID,
			int specialOfferID,
			decimal unitPrice,
			decimal unitPriceDiscount,
			decimal lineTotal,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.SalesOrderDetailID = salesOrderDetailID.ToInt();
			this.CarrierTrackingNumber = carrierTrackingNumber;
			this.OrderQty = orderQty;
			this.ProductID = productID.ToInt();
			this.UnitPrice = unitPrice;
			this.UnitPriceDiscount = unitPriceDiscount;
			this.LineTotal = lineTotal.ToDecimal();
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.SalesOrderID = new ReferenceEntity<int>(salesOrderID,
			                                             "SalesOrderHeader");
			this.SpecialOfferID = new ReferenceEntity<int>(specialOfferID,
			                                               "SpecialOfferProduct");
		}

		public ReferenceEntity<int> SalesOrderID { get; set; }
		public int SalesOrderDetailID { get; set; }
		public string CarrierTrackingNumber { get; set; }
		public short OrderQty { get; set; }
		public int ProductID { get; set; }
		public ReferenceEntity<int> SpecialOfferID { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal UnitPriceDiscount { get; set; }
		public decimal LineTotal { get; set; }
		public Guid Rowguid { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeSalesOrderIDValue { get; set; } = true;

		public bool ShouldSerializeSalesOrderID()
		{
			return this.ShouldSerializeSalesOrderIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesOrderDetailIDValue { get; set; } = true;

		public bool ShouldSerializeSalesOrderDetailID()
		{
			return this.ShouldSerializeSalesOrderDetailIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCarrierTrackingNumberValue { get; set; } = true;

		public bool ShouldSerializeCarrierTrackingNumber()
		{
			return this.ShouldSerializeCarrierTrackingNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOrderQtyValue { get; set; } = true;

		public bool ShouldSerializeOrderQty()
		{
			return this.ShouldSerializeOrderQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSpecialOfferIDValue { get; set; } = true;

		public bool ShouldSerializeSpecialOfferID()
		{
			return this.ShouldSerializeSpecialOfferIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeUnitPriceValue { get; set; } = true;

		public bool ShouldSerializeUnitPrice()
		{
			return this.ShouldSerializeUnitPriceValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeUnitPriceDiscountValue { get; set; } = true;

		public bool ShouldSerializeUnitPriceDiscount()
		{
			return this.ShouldSerializeUnitPriceDiscountValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLineTotalValue { get; set; } = true;

		public bool ShouldSerializeLineTotal()
		{
			return this.ShouldSerializeLineTotalValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeSalesOrderIDValue = false;
			this.ShouldSerializeSalesOrderDetailIDValue = false;
			this.ShouldSerializeCarrierTrackingNumberValue = false;
			this.ShouldSerializeOrderQtyValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeSpecialOfferIDValue = false;
			this.ShouldSerializeUnitPriceValue = false;
			this.ShouldSerializeUnitPriceDiscountValue = false;
			this.ShouldSerializeLineTotalValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>28fd9a8a72cd549d2cba5808d130b31b</Hash>
</Codenesium>*/