using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiCountryRegionResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string countryRegionCode,
                        DateTime modifiedDate,
                        string name)
                {
                        this.CountryRegionCode = countryRegionCode;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                public string CountryRegionCode { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeCountryRegionCodeValue { get; set; } = true;

                public bool ShouldSerializeCountryRegionCode()
                {
                        return this.ShouldSerializeCountryRegionCodeValue;
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
                        this.ShouldSerializeCountryRegionCodeValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>f417d24bb12959407158462f1016788f</Hash>
</Codenesium>*/