using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiWorkOrderRoutingResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int workOrderID,
                        decimal? actualCost,
                        DateTime? actualEndDate,
                        decimal? actualResourceHrs,
                        DateTime? actualStartDate,
                        short locationID,
                        DateTime modifiedDate,
                        short operationSequence,
                        decimal plannedCost,
                        int productID,
                        DateTime scheduledEndDate,
                        DateTime scheduledStartDate)
                {
                        this.WorkOrderID = workOrderID;
                        this.ActualCost = actualCost;
                        this.ActualEndDate = actualEndDate;
                        this.ActualResourceHrs = actualResourceHrs;
                        this.ActualStartDate = actualStartDate;
                        this.LocationID = locationID;
                        this.ModifiedDate = modifiedDate;
                        this.OperationSequence = operationSequence;
                        this.PlannedCost = plannedCost;
                        this.ProductID = productID;
                        this.ScheduledEndDate = scheduledEndDate;
                        this.ScheduledStartDate = scheduledStartDate;
                }

                public decimal? ActualCost { get; private set; }

                public DateTime? ActualEndDate { get; private set; }

                public decimal? ActualResourceHrs { get; private set; }

                public DateTime? ActualStartDate { get; private set; }

                public short LocationID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public short OperationSequence { get; private set; }

                public decimal PlannedCost { get; private set; }

                public int ProductID { get; private set; }

                public DateTime ScheduledEndDate { get; private set; }

                public DateTime ScheduledStartDate { get; private set; }

                public int WorkOrderID { get; private set; }

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

                public virtual void DisableAllFields()
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
    <Hash>612640916a3d96f402db1e9a36c26009</Hash>
</Codenesium>*/