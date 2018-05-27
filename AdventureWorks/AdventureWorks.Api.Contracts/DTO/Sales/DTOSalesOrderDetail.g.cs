using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOSalesOrderDetail: AbstractDTO
	{
		public DTOSalesOrderDetail() : base()
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

		public string CarrierTrackingNumber { get; set; }
		public decimal LineTotal { get; set; }
		public DateTime ModifiedDate { get; set; }
		public short OrderQty { get; set; }
		public int ProductID { get; set; }
		public Guid Rowguid { get; set; }
		public int SalesOrderDetailID { get; set; }
		public int SalesOrderID { get; set; }
		public int SpecialOfferID { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal UnitPriceDiscount { get; set; }
	}
}

/*<Codenesium>
    <Hash>deb89185cf15f8c08e8982fcd8c3b8f7</Hash>
</Codenesium>*/