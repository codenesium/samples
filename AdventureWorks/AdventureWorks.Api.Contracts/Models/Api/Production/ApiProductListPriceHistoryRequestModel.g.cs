using Codenesium.DataConversionExtensions;
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

                public virtual void SetProperties(
                        DateTime? endDate,
                        decimal listPrice,
                        DateTime modifiedDate,
                        DateTime startDate)
                {
                        this.EndDate = endDate;
                        this.ListPrice = listPrice;
                        this.ModifiedDate = modifiedDate;
                        this.StartDate = startDate;
                }

                private DateTime? endDate;

                public DateTime? EndDate
                {
                        get
                        {
                                return this.endDate;
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
    <Hash>30466072cd54c5ad3024c8311ab74def</Hash>
</Codenesium>*/