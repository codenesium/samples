using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("PurchaseOrderDetail", Schema="Purchasing")]
	public partial class EFPurchaseOrderDetail
	{
		public EFPurchaseOrderDetail()
		{}

		[Key]
		public int purchaseOrderID {get; set;}
		public int purchaseOrderDetailID {get; set;}
		public DateTime dueDate {get; set;}
		public short orderQty {get; set;}
		public int productID {get; set;}
		public decimal unitPrice {get; set;}
		public decimal lineTotal {get; set;}
		public decimal receivedQty {get; set;}
		public decimal rejectedQty {get; set;}
		public decimal stockedQty {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>bee8055c95402623242c03cb25912fff</Hash>
</Codenesium>*/