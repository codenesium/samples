using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiEmployeePayHistoryResponseModel : AbstractApiResponseModel
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

                public int BusinessEntityID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int PayFrequency { get; private set; }

                public decimal Rate { get; private set; }

                public DateTime RateChangeDate { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

                public bool ShouldSerializeBusinessEntityID()
                {
                        return this.ShouldSerializeBusinessEntityIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePayFrequencyValue { get; set; } = true;

                public bool ShouldSerializePayFrequency()
                {
                        return this.ShouldSerializePayFrequencyValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRateValue { get; set; } = true;

                public bool ShouldSerializeRate()
                {
                        return this.ShouldSerializeRateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRateChangeDateValue { get; set; } = true;

                public bool ShouldSerializeRateChangeDate()
                {
                        return this.ShouldSerializeRateChangeDateValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeBusinessEntityIDValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializePayFrequencyValue = false;
                        this.ShouldSerializeRateValue = false;
                        this.ShouldSerializeRateChangeDateValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>e5e1367aefd55ca7c313553c0500189b</Hash>
</Codenesium>*/