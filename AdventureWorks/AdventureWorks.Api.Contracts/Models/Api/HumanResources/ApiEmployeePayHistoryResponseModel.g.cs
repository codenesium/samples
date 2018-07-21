using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiEmployeePayHistoryResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int businessEntityID,
                        DateTime modifiedDate,
                        int payFrequency,
                        decimal rate,
                        DateTime rateChangeDate)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.PayFrequency = payFrequency;
                        this.Rate = rate;
                        this.RateChangeDate = rateChangeDate;
                }

                [JsonProperty]
                public int BusinessEntityID { get; private set; }

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [JsonProperty]
                public int PayFrequency { get; private set; }

                [JsonProperty]
                public decimal Rate { get; private set; }

                [JsonProperty]
                public DateTime RateChangeDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>215b8805ad91f2f73f8f377ebe73fabf</Hash>
</Codenesium>*/