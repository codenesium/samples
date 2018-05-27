using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("WorkOrderRouting", Schema="Production")]
	public partial class WorkOrderRouting: AbstractEntityFrameworkDTO
	{
		public WorkOrderRouting()
		{}

		public void SetProperties(
			int workOrderID,
			Nullable<decimal> actualCost,
			Nullable<DateTime> actualEndDate,
			Nullable<decimal> actualResourceHrs,
			Nullable<DateTime> actualStartDate,
			short locationID,
			DateTime modifiedDate,
			short operationSequence,
			decimal plannedCost,
			int productID,
			DateTime scheduledEndDate,
			DateTime scheduledStartDate)
		{
			this.ActualCost = actualCost.ToNullableDecimal();
			this.ActualEndDate = actualEndDate.ToNullableDateTime();
			this.ActualResourceHrs = actualResourceHrs.ToNullableDecimal();
			this.ActualStartDate = actualStartDate.ToNullableDateTime();
			this.LocationID = locationID;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.OperationSequence = operationSequence;
			this.PlannedCost = plannedCost.ToDecimal();
			this.ProductID = productID.ToInt();
			this.ScheduledEndDate = scheduledEndDate.ToDateTime();
			this.ScheduledStartDate = scheduledStartDate.ToDateTime();
			this.WorkOrderID = workOrderID.ToInt();
		}

		[Column("ActualCost", TypeName="money")]
		public Nullable<decimal> ActualCost { get; set; }

		[Column("ActualEndDate", TypeName="datetime")]
		public Nullable<DateTime> ActualEndDate { get; set; }

		[Column("ActualResourceHrs", TypeName="decimal")]
		public Nullable<decimal> ActualResourceHrs { get; set; }

		[Column("ActualStartDate", TypeName="datetime")]
		public Nullable<DateTime> ActualStartDate { get; set; }

		[Column("LocationID", TypeName="smallint")]
		public short LocationID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("OperationSequence", TypeName="smallint")]
		public short OperationSequence { get; set; }

		[Column("PlannedCost", TypeName="money")]
		public decimal PlannedCost { get; set; }

		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("ScheduledEndDate", TypeName="datetime")]
		public DateTime ScheduledEndDate { get; set; }

		[Column("ScheduledStartDate", TypeName="datetime")]
		public DateTime ScheduledStartDate { get; set; }

		[Key]
		[Column("WorkOrderID", TypeName="int")]
		public int WorkOrderID { get; set; }
	}
}

/*<Codenesium>
    <Hash>309789558984d8ebe0472a0e2b8680f6</Hash>
</Codenesium>*/