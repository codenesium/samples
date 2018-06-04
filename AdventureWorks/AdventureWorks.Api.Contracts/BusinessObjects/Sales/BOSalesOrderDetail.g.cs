using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOSalesOrderDetail: AbstractBusinessObject
	{
		public BOSalesOrderDetail() : base()
		{}

		public void SetProperties(int salesOrderID,
		                          string carrierTrackingNumber,
		                          decimal lineTotal,
		                          DateTime modifiedDate,
		                          short orderQty,
		                          int productID,
		                          Guid rowguid,
		                          int salesOrderDetailID,
		                          int specialOfferID,
		                          decimal unitPrice,
		                          decimal unitPriceDiscount)
		{
			this.CarrierTrackingNumber = carrierTrackingNumber;
			this.LineTotal = lineTotal.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.OrderQty = orderQty;
			this.ProductID = productID.ToInt();
			this.Rowguid = rowguid.ToGuid();
			this.SalesOrderDetailID = salesOrderDetailID.ToInt();
			this.SalesOrderID = salesOrderID.ToInt();
			this.SpecialOfferID = specialOfferID.ToInt();
			this.UnitPrice = unitPrice.ToDecimal();
			this.UnitPriceDiscount = unitPriceDiscount.ToDecimal();
		}

		public string CarrierTrackingNumber { get; private set; }
		public decimal LineTotal { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public short OrderQty { get; private set; }
		public int ProductID { get; private set; }
		public Guid Rowguid { get; private set; }
		public int SalesOrderDetailID { get; private set; }
		public int SalesOrderID { get; private set; }
		public int SpecialOfferID { get; private set; }
		public decimal UnitPrice { get; private set; }
		public decimal UnitPriceDiscount { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cb7b8cd4b91a2b3283a5803515ea4c85</Hash>
</Codenesium>*/