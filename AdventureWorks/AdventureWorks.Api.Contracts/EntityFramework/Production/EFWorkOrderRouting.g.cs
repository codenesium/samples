using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.Contracts
{
	[Table("WorkOrderRouting", Schema="Production")]
	public partial class EFWorkOrderRouting
	{
		public EFWorkOrderRouting()
		{}

		public void SetProperties(
			int workOrderID,
			int productID,
			short operationSequence,
			short locationID,
			DateTime scheduledStartDate,
			DateTime scheduledEndDate,
			Nullable<DateTime> actualStartDate,
			Nullable<DateTime> actualEndDate,
			Nullable<decimal> actualResourceHrs,
			decimal plannedCost,
			Nullable<decimal> actualCost,
			DateTime modifiedDate)
		{
			this.WorkOrderID = workOrderID.ToInt();
			this.ProductID = productID.ToInt();
			this.OperationSequence = operationSequence;
			this.LocationID = locationID;
			this.ScheduledStartDate = scheduledStartDate.ToDateTime();
			this.ScheduledEndDate = scheduledEndDate.ToDateTime();
			this.ActualStartDate = actualStartDate.ToNullableDateTime();
			this.ActualEndDate = actualEndDate.ToNullableDateTime();
			this.ActualResourceHrs = actualResourceHrs.ToNullableDecimal();
			this.PlannedCost = plannedCost;
			this.ActualCost = actualCost;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("WorkOrderID", TypeName="int")]
		public int WorkOrderID { get; set; }

		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("OperationSequence", TypeName="smallint")]
		public short OperationSequence { get; set; }

		[Column("LocationID", TypeName="smallint")]
		public short LocationID { get; set; }

		[Column("ScheduledStartDate", TypeName="datetime")]
		public DateTime ScheduledStartDate { get; set; }

		[Column("ScheduledEndDate", TypeName="datetime")]
		public DateTime ScheduledEndDate { get; set; }

		[Column("ActualStartDate", TypeName="datetime")]
		public Nullable<DateTime> ActualStartDate { get; set; }

		[Column("ActualEndDate", TypeName="datetime")]
		public Nullable<DateTime> ActualEndDate { get; set; }

		[Column("ActualResourceHrs", TypeName="decimal")]
		public Nullable<decimal> ActualResourceHrs { get; set; }

		[Column("PlannedCost", TypeName="money")]
		public decimal PlannedCost { get; set; }

		[Column("ActualCost", TypeName="money")]
		public Nullable<decimal> ActualCost { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("WorkOrderID")]
		public virtual EFWorkOrder WorkOrder { get; set; }

		[ForeignKey("LocationID")]
		public virtual EFLocation Location { get; set; }
	}
}

/*<Codenesium>
    <Hash>077a672f1f5eae27dbf60c266bb2c058</Hash>
</Codenesium>*/