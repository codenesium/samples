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
			DateTime scheduledStartDate,
			int workOrderID)
		{
			this.ActualCost = actualCost.ToNullableDecimal();
			this.ActualEndDate = actualEndDate.ToNullableDateTime();
			this.ActualResourceHrs = actualResourceHrs.ToNullableDecimal();
			this.ActualStartDate = actualStartDate.ToNullableDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.OperationSequence = operationSequence;
			this.PlannedCost = plannedCost.ToDecimal();
			this.ProductID = productID.ToInt();
			this.ScheduledEndDate = scheduledEndDate.ToDateTime();
			this.ScheduledStartDate = scheduledStartDate.ToDateTime();

			this.LocationID = new ReferenceEntity<short>(locationID,
			                                             nameof(ApiResponse.Locations));
			this.WorkOrderID = new ReferenceEntity<int>(workOrderID,
			                                            nameof(ApiResponse.WorkOrders));
		}

		public Nullable<decimal> ActualCost { get; set; }
		public Nullable<DateTime> ActualEndDate { get; set; }
		public Nullable<decimal> ActualResourceHrs { get; set; }
		public Nullable<DateTime> ActualStartDate { get; set; }
		public ReferenceEntity<short> LocationID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public short OperationSequence { get; set; }
		public decimal PlannedCost { get; set; }
		public int ProductID { get; set; }
		public DateTime ScheduledEndDate { get; set; }
		public DateTime ScheduledStartDate { get; set; }
		public ReferenceEntity<int> WorkOrderID { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeActualCostValue { get; set; } = true;

		public bool ShouldSerializeActualCost()
		{
			return this.ShouldSerializeActualCostValue;
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
		public bool ShouldSerializeActualStartDateValue { get; set; } = true;

		public bool ShouldSerializeActualStartDate()
		{
			return this.ShouldSerializeActualStartDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLocationIDValue { get; set; } = true;

		public bool ShouldSerializeLocationID()
		{
			return this.ShouldSerializeLocationIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOperationSequenceValue { get; set; } = true;

		public bool ShouldSerializeOperationSequence()
		{
			return this.ShouldSerializeOperationSequenceValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePlannedCostValue { get; set; } = true;

		public bool ShouldSerializePlannedCost()
		{
			return this.ShouldSerializePlannedCostValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeScheduledEndDateValue { get; set; } = true;

		public bool ShouldSerializeScheduledEndDate()
		{
			return this.ShouldSerializeScheduledEndDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeScheduledStartDateValue { get; set; } = true;

		public bool ShouldSerializeScheduledStartDate()
		{
			return this.ShouldSerializeScheduledStartDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeWorkOrderIDValue { get; set; } = true;

		public bool ShouldSerializeWorkOrderID()
		{
			return this.ShouldSerializeWorkOrderIDValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeActualCostValue = false;
			this.ShouldSerializeActualEndDateValue = false;
			this.ShouldSerializeActualResourceHrsValue = false;
			this.ShouldSerializeActualStartDateValue = false;
			this.ShouldSerializeLocationIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeOperationSequenceValue = false;
			this.ShouldSerializePlannedCostValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeScheduledEndDateValue = false;
			this.ShouldSerializeScheduledStartDateValue = false;
			this.ShouldSerializeWorkOrderIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>f8600539a05e1b9a9f7be30567120ebc</Hash>
</Codenesium>*/