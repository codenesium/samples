using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiWorkOrderRoutingRequestModel: AbstractApiRequestModel
        {
                public ApiWorkOrderRoutingRequestModel() : base()
                {
                }

                public void SetProperties(
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

                private Nullable<decimal> actualCost;

                public Nullable<decimal> ActualCost
                {
                        get
                        {
                                return this.actualCost.IsEmptyOrZeroOrNull() ? null : this.actualCost;
                        }

                        set
                        {
                                this.actualCost = value;
                        }
                }

                private Nullable<DateTime> actualEndDate;

                public Nullable<DateTime> ActualEndDate
                {
                        get
                        {
                                return this.actualEndDate.IsEmptyOrZeroOrNull() ? null : this.actualEndDate;
                        }

                        set
                        {
                                this.actualEndDate = value;
                        }
                }

                private Nullable<decimal> actualResourceHrs;

                public Nullable<decimal> ActualResourceHrs
                {
                        get
                        {
                                return this.actualResourceHrs.IsEmptyOrZeroOrNull() ? null : this.actualResourceHrs;
                        }

                        set
                        {
                                this.actualResourceHrs = value;
                        }
                }

                private Nullable<DateTime> actualStartDate;

                public Nullable<DateTime> ActualStartDate
                {
                        get
                        {
                                return this.actualStartDate.IsEmptyOrZeroOrNull() ? null : this.actualStartDate;
                        }

                        set
                        {
                                this.actualStartDate = value;
                        }
                }

                private short locationID;

                [Required]
                public short LocationID
                {
                        get
                        {
                                return this.locationID;
                        }

                        set
                        {
                                this.locationID = value;
                        }
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }

                private short operationSequence;

                [Required]
                public short OperationSequence
                {
                        get
                        {
                                return this.operationSequence;
                        }

                        set
                        {
                                this.operationSequence = value;
                        }
                }

                private decimal plannedCost;

                [Required]
                public decimal PlannedCost
                {
                        get
                        {
                                return this.plannedCost;
                        }

                        set
                        {
                                this.plannedCost = value;
                        }
                }

                private int productID;

                [Required]
                public int ProductID
                {
                        get
                        {
                                return this.productID;
                        }

                        set
                        {
                                this.productID = value;
                        }
                }

                private DateTime scheduledEndDate;

                [Required]
                public DateTime ScheduledEndDate
                {
                        get
                        {
                                return this.scheduledEndDate;
                        }

                        set
                        {
                                this.scheduledEndDate = value;
                        }
                }

                private DateTime scheduledStartDate;

                [Required]
                public DateTime ScheduledStartDate
                {
                        get
                        {
                                return this.scheduledStartDate;
                        }

                        set
                        {
                                this.scheduledStartDate = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>48c63239f9f296f20e3f8b4a5a98ba94</Hash>
</Codenesium>*/