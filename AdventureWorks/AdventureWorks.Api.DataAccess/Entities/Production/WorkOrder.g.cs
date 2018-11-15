using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("WorkOrder", Schema="Production")]
	public partial class WorkOrder : AbstractEntity
	{
		public WorkOrder()
		{
		}

		public virtual void SetProperties(
			DateTime dueDate,
			DateTime? endDate,
			DateTime modifiedDate,
			int orderQty,
			int productID,
			short scrappedQty,
			short? scrapReasonID,
			DateTime startDate,
			int stockedQty,
			int workOrderID)
		{
			this.DueDate = dueDate;
			this.EndDate = endDate;
			this.ModifiedDate = modifiedDate;
			this.OrderQty = orderQty;
			this.ProductID = productID;
			this.ScrappedQty = scrappedQty;
			this.ScrapReasonID = scrapReasonID;
			this.StartDate = startDate;
			this.StockedQty = stockedQty;
			this.WorkOrderID = workOrderID;
		}

		[Column("DueDate")]
		public virtual DateTime DueDate { get; private set; }

		[Column("EndDate")]
		public virtual DateTime? EndDate { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("OrderQty")]
		public virtual int OrderQty { get; private set; }

		[Column("ProductID")]
		public virtual int ProductID { get; private set; }

		[Column("ScrappedQty")]
		public virtual short ScrappedQty { get; private set; }

		[Column("ScrapReasonID")]
		public virtual short? ScrapReasonID { get; private set; }

		[Column("StartDate")]
		public virtual DateTime StartDate { get; private set; }

		[Column("StockedQty")]
		public virtual int StockedQty { get; private set; }

		[Key]
		[Column("WorkOrderID")]
		public virtual int WorkOrderID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>846502ec9fbcbeeacbef87e2f342b221</Hash>
</Codenesium>*/