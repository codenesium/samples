using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiStateProvinceResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string countryRegionCode,
                        bool isOnlyStateProvinceFlag,
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid,
                        string stateProvinceCode,
                        int stateProvinceID,
                        int territoryID)
                {
                        this.CountryRegionCode = countryRegionCode;
                        this.IsOnlyStateProvinceFlag = isOnlyStateProvinceFlag;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                        this.StateProvinceCode = stateProvinceCode;
                        this.StateProvinceID = stateProvinceID;
                        this.TerritoryID = territoryID;
                }

                public string CountryRegionCode { get; private set; }

                public bool IsOnlyStateProvinceFlag { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public Guid Rowguid { get; private set; }

                public string StateProvinceCode { get; private set; }

                public int StateProvinceID { get; private set; }

                public int TerritoryID { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeCountryRegionCodeValue { get; set; } = true;

                public bool ShouldSerializeCountryRegionCode()
                {
                        return this.ShouldSerializeCountryRegionCodeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIsOnlyStateProvinceFlagValue { get; set; } = true;

                public bool ShouldSerializeIsOnlyStateProvinceFlag()
                {
                        return this.ShouldSerializeIsOnlyStateProvinceFlagValue;
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

                [JsonIgnore]
                public bool ShouldSerializeRowguidValue { get; set; } = true;

                public bool ShouldSerializeRowguid()
                {
                        return this.ShouldSerializeRowguidValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStateProvinceCodeValue { get; set; } = true;

                public bool ShouldSerializeStateProvinceCode()
                {
                        return this.ShouldSerializeStateProvinceCodeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStateProvinceIDValue { get; set; } = true;

                public bool ShouldSerializeStateProvinceID()
                {
                        return this.ShouldSerializeStateProvinceIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTerritoryIDValue { get; set; } = true;

                public bool ShouldSerializeTerritoryID()
                {
                        return this.ShouldSerializeTerritoryIDValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCountryRegionCodeValue = false;
                        this.ShouldSerializeIsOnlyStateProvinceFlagValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeRowguidValue = false;
                        this.ShouldSerializeStateProvinceCodeValue = false;
                        this.ShouldSerializeStateProvinceIDValue = false;
                        this.ShouldSerializeTerritoryIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>571fd2d9b1ab59fca72032f49e8514b0</Hash>
</Codenesium>*/