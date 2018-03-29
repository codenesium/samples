using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("WorkOrder", Schema="Production")]
	public partial class EFWorkOrder
	{
		public EFWorkOrder()
		{}

		[Key]
		public int WorkOrderID {get; set;}
		public int ProductID {get; set;}
		public int OrderQty {get; set;}
		public int StockedQty {get; set;}
		public short ScrappedQty {get; set;}
		public DateTime StartDate {get; set;}
		public Nullable<DateTime> EndDate {get; set;}
		public DateTime DueDate {get; set;}
		public Nullable<short> ScrapReasonID {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductID")]
		public virtual EFProduct ProductRef { get; set; }
		[ForeignKey("ScrapReasonID")]
		public virtual EFScrapReason ScrapReasonRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>7ebf2e61b333aca3a65be52215ec7652</Hash>
</Codenesium>*/