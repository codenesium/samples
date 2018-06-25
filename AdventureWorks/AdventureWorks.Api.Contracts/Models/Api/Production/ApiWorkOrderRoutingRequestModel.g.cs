using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiWorkOrderRoutingRequestModel : AbstractApiRequestModel
        {
                public ApiWorkOrderRoutingRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
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

                private decimal? actualCost;

                public decimal? ActualCost
                {
                        get
                        {
                                return this.actualCost;
                        }

                        set
                        {
                                this.actualCost = value;
                        }
                }

                private DateTime? actualEndDate;

                public DateTime? ActualEndDate
                {
                        get
                        {
                                return this.actualEndDate;
                        }

                        set
                        {
                                this.actualEndDate = value;
                        }
                }

                private decimal? actualResourceHrs;

                public decimal? ActualResourceHrs
                {
                        get
                        {
                                return this.actualResourceHrs;
                        }

                        set
                        {
                                this.actualResourceHrs = value;
                        }
                }

                private DateTime? actualStartDate;

                public DateTime? ActualStartDate
                {
                        get
                        {
                                return this.actualStartDate;
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
    <Hash>503e8b46d3d5515e52ed4e1a0ef365c9</Hash>
</Codenesium>*/