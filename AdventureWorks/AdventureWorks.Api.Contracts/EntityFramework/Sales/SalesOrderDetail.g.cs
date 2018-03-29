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
		public int SalesOrderID {get; set;}
		public int SalesOrderDetailID {get; set;}
		public string CarrierTrackingNumber {get; set;}
		public short OrderQty {get; set;}
		public int ProductID {get; set;}
		public int SpecialOfferID {get; set;}
		public decimal UnitPrice {get; set;}
		public decimal UnitPriceDiscount {get; set;}
		public decimal LineTotal {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("SalesOrderID")]
		public virtual EFSalesOrderHeader SalesOrderHeaderRef { get; set; }
		[ForeignKey("SpecialOfferID")]
		public virtual EFSpecialOfferProduct SpecialOfferProductRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>cbfb63d36bfe1c4c2ac36cba0438f5b7</Hash>
</Codenesium>*/