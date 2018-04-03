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
		public int salesOrderID {get; set;}
		public int salesOrderDetailID {get; set;}
		public string carrierTrackingNumber {get; set;}
		public short orderQty {get; set;}
		public int productID {get; set;}
		public int specialOfferID {get; set;}
		public decimal unitPrice {get; set;}
		public decimal unitPriceDiscount {get; set;}
		public decimal lineTotal {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>40d0260ac8efea9379bcee64b909a47f</Hash>
</Codenesium>*/