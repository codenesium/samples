using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesOrderDetail", Schema="Sales")]
	public partial class SalesOrderDetail: AbstractEntityFrameworkPOCO
	{
		public SalesOrderDetail()
		{}

		public void SetProperties(
			int salesOrderID,
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

		[Column("CarrierTrackingNumber", TypeName="nvarchar(25)")]
		public string CarrierTrackingNumber { get; set; }

		[Column("LineTotal", TypeName="decimal")]
		public decimal LineTotal { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("OrderQty", TypeName="smallint")]
		public short OrderQty { get; set; }

		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("SalesOrderDetailID", TypeName="int")]
		public int SalesOrderDetailID { get; set; }

		[Key]
		[Column("SalesOrderID", TypeName="int")]
		public int SalesOrderID { get; set; }

		[Column("SpecialOfferID", TypeName="int")]
		public int SpecialOfferID { get; set; }

		[Column("UnitPrice", TypeName="money")]
		public decimal UnitPrice { get; set; }

		[Column("UnitPriceDiscount", TypeName="money")]
		public decimal UnitPriceDiscount { get; set; }

		[ForeignKey("ProductID")]
		public virtual SpecialOfferProduct SpecialOfferProduct { get; set; }

		[ForeignKey("SalesOrderID")]
		public virtual SalesOrderHeader SalesOrderHeader { get; set; }

		[ForeignKey("SpecialOfferID")]
		public virtual SpecialOfferProduct SpecialOfferProduct1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>510b6d19a7e6a25d890a39e2f93304c4</Hash>
</Codenesium>*/