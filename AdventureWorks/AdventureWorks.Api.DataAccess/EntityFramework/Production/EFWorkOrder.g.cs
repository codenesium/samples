using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("WorkOrder", Schema="Production")]
	public partial class EFWorkOrder
	{
		public EFWorkOrder()
		{}

		public void SetProperties(
			int workOrderID,
			int productID,
			int orderQty,
			int stockedQty,
			short scrappedQty,
			DateTime startDate,
			Nullable<DateTime> endDate,
			DateTime dueDate,
			Nullable<short> scrapReasonID,
			DateTime modifiedDate)
		{
			this.WorkOrderID = workOrderID.ToInt();
			this.ProductID = productID.ToInt();
			this.OrderQty = orderQty.ToInt();
			this.StockedQty = stockedQty.ToInt();
			this.ScrappedQty = scrappedQty;
			this.StartDate = startDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.DueDate = dueDate.ToDateTime();
			this.ScrapReasonID = scrapReasonID;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("WorkOrderID", TypeName="int")]
		public int WorkOrderID { get; set; }

		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("OrderQty", TypeName="int")]
		public int OrderQty { get; set; }

		[Column("StockedQty", TypeName="int")]
		public int StockedQty { get; set; }

		[Column("ScrappedQty", TypeName="smallint")]
		public short ScrappedQty { get; set; }

		[Column("StartDate", TypeName="datetime")]
		public DateTime StartDate { get; set; }

		[Column("EndDate", TypeName="datetime")]
		public Nullable<DateTime> EndDate { get; set; }

		[Column("DueDate", TypeName="datetime")]
		public DateTime DueDate { get; set; }

		[Column("ScrapReasonID", TypeName="smallint")]
		public Nullable<short> ScrapReasonID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("ProductID")]
		public virtual EFProduct Product { get; set; }

		[ForeignKey("ScrapReasonID")]
		public virtual EFScrapReason ScrapReason { get; set; }
	}
}

/*<Codenesium>
    <Hash>5b6e9cc65c3f3f6df66b44d4219462a8</Hash>
</Codenesium>*/