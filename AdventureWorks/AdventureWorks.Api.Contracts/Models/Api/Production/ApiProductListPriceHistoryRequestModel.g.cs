using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductListPriceHistoryRequestModel : AbstractApiRequestModel
        {
                public ApiProductListPriceHistoryRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        Nullable<DateTime> endDate,
                        decimal listPrice,
                        DateTime modifiedDate,
                        DateTime startDate)
                {
                        this.EndDate = endDate;
                        this.ListPrice = listPrice;
                        this.ModifiedDate = modifiedDate;
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

                private decimal listPrice;

                [Required]
                public decimal ListPrice
                {
                        get
                        {
                                return this.listPrice;
                        }

                        set
                        {
                                this.listPrice = value;
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
    <Hash>542eb7a94a46e579a956a27c20ccc980</Hash>
</Codenesium>*/