using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("WorkOrder", Schema="Production")]
	public partial class WorkOrder: AbstractEntityFrameworkPOCO
	{
		public WorkOrder()
		{}

		public void SetProperties(
			int workOrderID,
			DateTime dueDate,
			Nullable<DateTime> endDate,
			DateTime modifiedDate,
			int orderQty,
			int productID,
			short scrappedQty,
			Nullable<short> scrapReasonID,
			DateTime startDate,
			int stockedQty)
		{
			this.DueDate = dueDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.OrderQty = orderQty.ToInt();
			this.ProductID = productID.ToInt();
			this.ScrappedQty = scrappedQty;
			this.ScrapReasonID = scrapReasonID;
			this.StartDate = startDate.ToDateTime();
			this.StockedQty = stockedQty.ToInt();
			this.WorkOrderID = workOrderID.ToInt();
		}

		[Column("DueDate", TypeName="datetime")]
		public DateTime DueDate { get; set; }

		[Column("EndDate", TypeName="datetime")]
		public Nullable<DateTime> EndDate { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("OrderQty", TypeName="int")]
		public int OrderQty { get; set; }

		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("ScrappedQty", TypeName="smallint")]
		public short ScrappedQty { get; set; }

		[Column("ScrapReasonID", TypeName="smallint")]
		public Nullable<short> ScrapReasonID { get; set; }

		[Column("StartDate", TypeName="datetime")]
		public DateTime StartDate { get; set; }

		[Column("StockedQty", TypeName="int")]
		public int StockedQty { get; set; }

		[Key]
		[Column("WorkOrderID", TypeName="int")]
		public int WorkOrderID { get; set; }
	}
}

/*<Codenesium>
    <Hash>fa08da26ff7fad111c255091fba151ac</Hash>
</Codenesium>*/