using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SalesOrderDetail", Schema="Sales")]
	public partial class EFSalesOrderDetail
	{
		public EFSalesOrderDetail()
		{}

		public void SetProperties(int salesOrderID,
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
			this.SalesOrderID = salesOrderID.ToInt();
			this.SalesOrderDetailID = salesOrderDetailID.ToInt();
			this.CarrierTrackingNumber = carrierTrackingNumber;
			this.OrderQty = orderQty;
			this.ProductID = productID.ToInt();
			this.SpecialOfferID = specialOfferID.ToInt();
			this.UnitPrice = unitPrice;
			this.UnitPriceDiscount = unitPriceDiscount;
			this.LineTotal = lineTotal.ToDecimal();
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("SalesOrderID", TypeName="int")]
		public int SalesOrderID {get; set;}

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("SalesOrderDetailID", TypeName="int")]
		public int SalesOrderDetailID {get; set;}

		[Column("CarrierTrackingNumber", TypeName="nvarchar(25)")]
		public string CarrierTrackingNumber {get; set;}

		[Column("OrderQty", TypeName="smallint")]
		public short OrderQty {get; set;}

		[Column("ProductID", TypeName="int")]
		public int ProductID {get; set;}

		[Column("SpecialOfferID", TypeName="int")]
		public int SpecialOfferID {get; set;}

		[Column("UnitPrice", TypeName="money")]
		public decimal UnitPrice {get; set;}

		[Column("UnitPriceDiscount", TypeName="money")]
		public decimal UnitPriceDiscount {get; set;}

		[Column("LineTotal", TypeName="numeric")]
		public decimal LineTotal {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFSalesOrderHeader SalesOrderHeader { get; set; }

		public virtual EFSpecialOfferProduct SpecialOfferProduct { get; set; }
	}
}

/*<Codenesium>
    <Hash>988c30e4db0c0ecd4ecf98e1961bffd0</Hash>
</Codenesium>*/