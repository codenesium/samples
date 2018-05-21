using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOSalesOrderDetail: AbstractPOCO
	{
		public POCOSalesOrderDetail() : base()
		{}

		public POCOSalesOrderDetail(
			string carrierTrackingNumber,
			decimal lineTotal,
			DateTime modifiedDate,
			short orderQty,
			int productID,
			Guid rowguid,
			int salesOrderDetailID,
			int salesOrderID,
			int specialOfferID,
			decimal unitPrice,
			decimal unitPriceDiscount)
		{
			this.CarrierTrackingNumber = carrierTrackingNumber;
			this.LineTotal = lineTotal.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.OrderQty = orderQty;
			this.Rowguid = rowguid.ToGuid();
			this.SalesOrderDetailID = salesOrderDetailID.ToInt();
			this.UnitPrice = unitPrice.ToDecimal();
			this.UnitPriceDiscount = unitPriceDiscount.ToDecimal();

			this.ProductID = new ReferenceEntity<int>(productID,
			                                          nameof(ApiResponse.SpecialOfferProducts));
			this.SalesOrderID = new ReferenceEntity<int>(salesOrderID,
			                                             nameof(ApiResponse.SalesOrderHeaders));
			this.SpecialOfferID = new ReferenceEntity<int>(specialOfferID,
			                                               nameof(ApiResponse.SpecialOfferProducts));
		}

		public string CarrierTrackingNumber { get; set; }
		public decimal LineTotal { get; set; }
		public DateTime ModifiedDate { get; set; }
		public short OrderQty { get; set; }
		public ReferenceEntity<int> ProductID { get; set; }
		public Guid Rowguid { get; set; }
		public int SalesOrderDetailID { get; set; }
		public ReferenceEntity<int> SalesOrderID { get; set; }
		public ReferenceEntity<int> SpecialOfferID { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal UnitPriceDiscount { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeCarrierTrackingNumberValue { get; set; } = true;

		public bool ShouldSerializeCarrierTrackingNumber()
		{
			return this.ShouldSerializeCarrierTrackingNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLineTotalValue { get; set; } = true;

		public bool ShouldSerializeLineTotal()
		{
			return this.ShouldSerializeLineTotalValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
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
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesOrderDetailIDValue { get; set; } = true;

		public bool ShouldSerializeSalesOrderDetailID()
		{
			return this.ShouldSerializeSalesOrderDetailIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesOrderIDValue { get; set; } = true;

		public bool ShouldSerializeSalesOrderID()
		{
			return this.ShouldSerializeSalesOrderIDValue;
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

		public void DisableAllFields()
		{
			this.ShouldSerializeCarrierTrackingNumberValue = false;
			this.ShouldSerializeLineTotalValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeOrderQtyValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeSalesOrderDetailIDValue = false;
			this.ShouldSerializeSalesOrderIDValue = false;
			this.ShouldSerializeSpecialOfferIDValue = false;
			this.ShouldSerializeUnitPriceValue = false;
			this.ShouldSerializeUnitPriceDiscountValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>fcb2c6484447233d99bcf6f8a42a503f</Hash>
</Codenesium>*/