using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOWorkOrderRouting
	{
		public POCOWorkOrderRouting()
		{}

		public POCOWorkOrderRouting(
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
			this.ProductID = productID.ToInt();
			this.OperationSequence = operationSequence;
			this.ScheduledStartDate = scheduledStartDate.ToDateTime();
			this.ScheduledEndDate = scheduledEndDate.ToDateTime();
			this.ActualStartDate = actualStartDate.ToNullableDateTime();
			this.ActualEndDate = actualEndDate.ToNullableDateTime();
			this.ActualResourceHrs = actualResourceHrs.ToNullableDecimal();
			this.PlannedCost = plannedCost;
			this.ActualCost = actualCost;
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.WorkOrderID = new ReferenceEntity<int>(workOrderID,
			                                            "WorkOrder");
			this.LocationID = new ReferenceEntity<short>(locationID,
			                                             "Location");
		}

		public ReferenceEntity<int> WorkOrderID { get; set; }
		public int ProductID { get; set; }
		public short OperationSequence { get; set; }
		public ReferenceEntity<short> LocationID { get; set; }
		public DateTime ScheduledStartDate { get; set; }
		public DateTime ScheduledEndDate { get; set; }
		public Nullable<DateTime> ActualStartDate { get; set; }
		public Nullable<DateTime> ActualEndDate { get; set; }
		public Nullable<decimal> ActualResourceHrs { get; set; }
		public decimal PlannedCost { get; set; }
		public Nullable<decimal> ActualCost { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeWorkOrderIDValue { get; set; } = true;

		public bool ShouldSerializeWorkOrderID()
		{
			return this.ShouldSerializeWorkOrderIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOperationSequenceValue { get; set; } = true;

		public bool ShouldSerializeOperationSequence()
		{
			return this.ShouldSerializeOperationSequenceValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLocationIDValue { get; set; } = true;

		public bool ShouldSerializeLocationID()
		{
			return this.ShouldSerializeLocationIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeScheduledStartDateValue { get; set; } = true;

		public bool ShouldSerializeScheduledStartDate()
		{
			return this.ShouldSerializeScheduledStartDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeScheduledEndDateValue { get; set; } = true;

		public bool ShouldSerializeScheduledEndDate()
		{
			return this.ShouldSerializeScheduledEndDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeActualStartDateValue { get; set; } = true;

		public bool ShouldSerializeActualStartDate()
		{
			return this.ShouldSerializeActualStartDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeActualEndDateValue { get; set; } = true;

		public bool ShouldSerializeActualEndDate()
		{
			return this.ShouldSerializeActualEndDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeActualResourceHrsValue { get; set; } = true;

		public bool ShouldSerializeActualResourceHrs()
		{
			return this.ShouldSerializeActualResourceHrsValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePlannedCostValue { get; set; } = true;

		public bool ShouldSerializePlannedCost()
		{
			return this.ShouldSerializePlannedCostValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeActualCostValue { get; set; } = true;

		public bool ShouldSerializeActualCost()
		{
			return this.ShouldSerializeActualCostValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeWorkOrderIDValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeOperationSequenceValue = false;
			this.ShouldSerializeLocationIDValue = false;
			this.ShouldSerializeScheduledStartDateValue = false;
			this.ShouldSerializeScheduledEndDateValue = false;
			this.ShouldSerializeActualStartDateValue = false;
			this.ShouldSerializeActualEndDateValue = false;
			this.ShouldSerializeActualResourceHrsValue = false;
			this.ShouldSerializePlannedCostValue = false;
			this.ShouldSerializeActualCostValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>54c5476802b04c25d4d8698812301005</Hash>
</Codenesium>*/