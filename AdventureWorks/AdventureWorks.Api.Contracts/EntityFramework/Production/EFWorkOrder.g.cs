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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("WorkOrderID", TypeName="int")]
		public int WorkOrderID {get; set;}

		[Column("ProductID", TypeName="int")]
		public int ProductID {get; set;}

		[Column("OrderQty", TypeName="int")]
		public int OrderQty {get; set;}

		[Column("StockedQty", TypeName="int")]
		public int StockedQty {get; set;}

		[Column("ScrappedQty", TypeName="smallint")]
		public short ScrappedQty {get; set;}

		[Column("StartDate", TypeName="datetime")]
		public DateTime StartDate {get; set;}

		[Column("EndDate", TypeName="datetime")]
		public Nullable<DateTime> EndDate {get; set;}

		[Column("DueDate", TypeName="datetime")]
		public DateTime DueDate {get; set;}

		[Column("ScrapReasonID", TypeName="smallint")]
		public Nullable<short> ScrapReasonID {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductID")]
		public virtual EFProduct Product { get; set; }
		[ForeignKey("ScrapReasonID")]
		public virtual EFScrapReason ScrapReason { get; set; }
	}
}

/*<Codenesium>
    <Hash>f12f65bb24af17d4f4164d18624a06be</Hash>
</Codenesium>*/