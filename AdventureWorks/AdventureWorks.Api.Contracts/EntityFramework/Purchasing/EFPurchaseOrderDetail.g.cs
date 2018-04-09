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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("PurchaseOrderID", TypeName="int")]
		public int PurchaseOrderID {get; set;}

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("PurchaseOrderDetailID", TypeName="int")]
		public int PurchaseOrderDetailID {get; set;}

		[Column("DueDate", TypeName="datetime")]
		public DateTime DueDate {get; set;}

		[Column("OrderQty", TypeName="smallint")]
		public short OrderQty {get; set;}

		[Column("ProductID", TypeName="int")]
		public int ProductID {get; set;}

		[Column("UnitPrice", TypeName="money")]
		public decimal UnitPrice {get; set;}

		[Column("LineTotal", TypeName="money")]
		public decimal LineTotal {get; set;}

		[Column("ReceivedQty", TypeName="decimal")]
		public decimal ReceivedQty {get; set;}

		[Column("RejectedQty", TypeName="decimal")]
		public decimal RejectedQty {get; set;}

		[Column("StockedQty", TypeName="decimal")]
		public decimal StockedQty {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFPurchaseOrderHeader PurchaseOrderHeader { get; set; }

		public virtual EFProduct Product { get; set; }
	}
}

/*<Codenesium>
    <Hash>424cbab35531708ec9a921e325abcd15</Hash>
</Codenesium>*/