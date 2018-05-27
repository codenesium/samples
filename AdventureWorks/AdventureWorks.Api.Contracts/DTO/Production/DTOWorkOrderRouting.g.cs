using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOWorkOrderRouting: AbstractDTO
	{
		public DTOWorkOrderRouting() : base()
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

		public Nullable<decimal> ActualCost { get; set; }
		public Nullable<DateTime> ActualEndDate { get; set; }
		public Nullable<decimal> ActualResourceHrs { get; set; }
		public Nullable<DateTime> ActualStartDate { get; set; }
		public short LocationID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public short OperationSequence { get; set; }
		public decimal PlannedCost { get; set; }
		public int ProductID { get; set; }
		public DateTime ScheduledEndDate { get; set; }
		public DateTime ScheduledStartDate { get; set; }
		public int WorkOrderID { get; set; }
	}
}

/*<Codenesium>
    <Hash>b91a355944d999b954d47556dd3217fa</Hash>
</Codenesium>*/