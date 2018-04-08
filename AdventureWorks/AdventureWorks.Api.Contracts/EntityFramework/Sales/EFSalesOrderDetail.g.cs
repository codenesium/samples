using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SalesOrderDetail", Schema="Sales")]
	public partial class EFSalesOrderDetail
	{
		public EFSalesOrderDetail()
		{}

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

		[ForeignKey("SalesOrderID")]
		public virtual EFSalesOrderHeader SalesOrderHeader { get; set; }
		[ForeignKey("SpecialOfferID")]
		public virtual EFSpecialOfferProduct SpecialOfferProduct { get; set; }
	}
}

/*<Codenesium>
    <Hash>0a2785cd5a5dece2085f254c9c0bf606</Hash>
</Codenesium>*/