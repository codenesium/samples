using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductVendor", Schema="Purchasing")]
	public partial class EFProductVendor
	{
		public EFProductVendor()
		{}

		[Key]
		public int productID {get; set;}
		public int businessEntityID {get; set;}
		public int averageLeadTime {get; set;}
		public decimal standardPrice {get; set;}
		public Nullable<decimal> lastReceiptCost {get; set;}
		public Nullable<DateTime> lastReceiptDate {get; set;}
		public int minOrderQty {get; set;}
		public int maxOrderQty {get; set;}
		public Nullable<int> onOrderQty {get; set;}
		public string unitMeasureCode {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>d49973ef215b73d6571c40b12733e905</Hash>
</Codenesium>*/