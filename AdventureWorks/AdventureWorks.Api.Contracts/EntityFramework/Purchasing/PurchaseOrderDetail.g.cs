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
		public int PurchaseOrderID {get; set;}
		public int PurchaseOrderDetailID {get; set;}
		public DateTime DueDate {get; set;}
		public short OrderQty {get; set;}
		public int ProductID {get; set;}
		public decimal UnitPrice {get; set;}
		public decimal LineTotal {get; set;}
		public decimal ReceivedQty {get; set;}
		public decimal RejectedQty {get; set;}
		public decimal StockedQty {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("PurchaseOrderID")]
		public virtual EFPurchaseOrderHeader PurchaseOrderHeaderRef { get; set; }
		[ForeignKey("ProductID")]
		public virtual EFProduct ProductRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>fbcb4c991ff610270b4da28daeb74820</Hash>
</Codenesium>*/