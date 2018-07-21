using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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

                [JsonProperty]
                public DateTime? EndDate { get; private set; }

                [Required]
                [JsonProperty]
                public decimal ListPrice { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime StartDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2a41bdb8e9c3e9e73cbe31a5005b5ff2</Hash>
</Codenesium>*/