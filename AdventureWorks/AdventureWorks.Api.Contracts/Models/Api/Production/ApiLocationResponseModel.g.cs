using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiLocationResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        decimal availability,
                        decimal costRate,
                        short locationID,
                        DateTime modifiedDate,
                        string name)
                {
                        this.Availability = availability;
                        this.CostRate = costRate;
                        this.LocationID = locationID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                public decimal Availability { get; private set; }

                public decimal CostRate { get; private set; }

                public short LocationID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAvailabilityValue { get; set; } = true;

                public bool ShouldSerializeAvailability()
                {
                        return this.ShouldSerializeAvailabilityValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCostRateValue { get; set; } = true;

                public bool ShouldSerializeCostRate()
                {
                        return this.ShouldSerializeCostRateValue;
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
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAvailabilityValue = false;
                        this.ShouldSerializeCostRateValue = false;
                        this.ShouldSerializeLocationIDValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>55353b9327a9bbf3ed18c2102f58f7f8</Hash>
</Codenesium>*/