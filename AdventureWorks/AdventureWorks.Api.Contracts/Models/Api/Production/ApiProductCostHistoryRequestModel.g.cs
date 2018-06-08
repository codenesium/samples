using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductCostHistoryRequestModel: AbstractApiRequestModel
        {
                public ApiProductCostHistoryRequestModel() : base()
                {
                }

                public void SetProperties(
                        Nullable<DateTime> endDate,
                        DateTime modifiedDate,
                        decimal standardCost,
                        DateTime startDate)
                {
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.StandardCost = standardCost;
                        this.StartDate = startDate;
                }

                private Nullable<DateTime> endDate;

                public Nullable<DateTime> EndDate
                {
                        get
                        {
                                return this.endDate.IsEmptyOrZeroOrNull() ? null : this.endDate;
                        }

                        set
                        {
                                this.endDate = value;
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

                private decimal standardCost;

                [Required]
                public decimal StandardCost
                {
                        get
                        {
                                return this.standardCost;
                        }

                        set
                        {
                                this.standardCost = value;
                        }
                }

                private DateTime startDate;

                [Required]
                public DateTime StartDate
                {
                        get
                        {
                                return this.startDate;
                        }

                        set
                        {
                                this.startDate = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>cfdab57d8ed4d504e3bcf522d2f41584</Hash>
</Codenesium>*/