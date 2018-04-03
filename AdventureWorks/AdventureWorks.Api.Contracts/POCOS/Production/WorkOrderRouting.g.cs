using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOWorkOrderRouting
	{
		public POCOWorkOrderRouting()
		{}

		public POCOWorkOrderRouting(int workOrderID,
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

		public int WorkOrderID {get; set;}
		public int ProductID {get; set;}
		public short OperationSequence {get; set;}
		public short LocationID {get; set;}
		public DateTime ScheduledStartDate {get; set;}
		public DateTime ScheduledEndDate {get; set;}
		public Nullable<DateTime> ActualStartDate {get; set;}
		public Nullable<DateTime> ActualEndDate {get; set;}
		public Nullable<decimal> ActualResourceHrs {get; set;}
		public decimal PlannedCost {get; set;}
		public Nullable<decimal> ActualCost {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeWorkOrderIDValue {get; set;} = true;

		public bool ShouldSerializeWorkOrderID()
		{
			return ShouldSerializeWorkOrderIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue {get; set;} = true;

		public bool ShouldSerializeProductID()
		{
			return ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOperationSequenceValue {get; set;} = true;

		public bool ShouldSerializeOperationSequence()
		{
			return ShouldSerializeOperationSequenceValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLocationIDValue {get; set;} = true;

		public bool ShouldSerializeLocationID()
		{
			return ShouldSerializeLocationIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeScheduledStartDateValue {get; set;} = true;

		public bool ShouldSerializeScheduledStartDate()
		{
			return ShouldSerializeScheduledStartDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeScheduledEndDateValue {get; set;} = true;

		public bool ShouldSerializeScheduledEndDate()
		{
			return ShouldSerializeScheduledEndDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeActualStartDateValue {get; set;} = true;

		public bool ShouldSerializeActualStartDate()
		{
			return ShouldSerializeActualStartDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeActualEndDateValue {get; set;} = true;

		public bool ShouldSerializeActualEndDate()
		{
			return ShouldSerializeActualEndDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeActualResourceHrsValue {get; set;} = true;

		public bool ShouldSerializeActualResourceHrs()
		{
			return ShouldSerializeActualResourceHrsValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePlannedCostValue {get; set;} = true;

		public bool ShouldSerializePlannedCost()
		{
			return ShouldSerializePlannedCostValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeActualCostValue {get; set;} = true;

		public bool ShouldSerializeActualCost()
		{
			return ShouldSerializeActualCostValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
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
    <Hash>c729641727871be3d19968e2242bf382</Hash>
</Codenesium>*/