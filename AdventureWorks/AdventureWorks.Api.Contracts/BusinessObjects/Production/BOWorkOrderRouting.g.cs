using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOWorkOrderRouting: AbstractBusinessObject
	{
		public BOWorkOrderRouting() : base()
		{}

		public void SetProperties(int workOrderID,
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

		public Nullable<decimal> ActualCost { get; private set; }
		public Nullable<DateTime> ActualEndDate { get; private set; }
		public Nullable<decimal> ActualResourceHrs { get; private set; }
		public Nullable<DateTime> ActualStartDate { get; private set; }
		public short LocationID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public short OperationSequence { get; private set; }
		public decimal PlannedCost { get; private set; }
		public int ProductID { get; private set; }
		public DateTime ScheduledEndDate { get; private set; }
		public DateTime ScheduledStartDate { get; private set; }
		public int WorkOrderID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>98821c07fdd6d1c59f01754298414187</Hash>
</Codenesium>*/