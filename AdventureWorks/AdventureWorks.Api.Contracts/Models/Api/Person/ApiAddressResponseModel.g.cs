using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiAddressResponseModel: AbstractApiResponseModel
        {
                public ApiAddressResponseModel() : base()
                {
                }

                public void SetProperties(
                        int addressID,
                        string addressLine1,
                        string addressLine2,
                        string city,
                        DateTime modifiedDate,
                        string postalCode,
                        Guid rowguid,
                        int stateProvinceID)
                {
                        this.AddressID = addressID;
                        this.AddressLine1 = addressLine1;
                        this.AddressLine2 = addressLine2;
                        this.City = city;
                        this.ModifiedDate = modifiedDate;
                        this.PostalCode = postalCode;
                        this.Rowguid = rowguid;
                        this.StateProvinceID = stateProvinceID;
                }

                public int AddressID { get; private set; }

                public string AddressLine1 { get; private set; }

                public string AddressLine2 { get; private set; }

                public string City { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string PostalCode { get; private set; }

                public Guid Rowguid { get; private set; }

                public int StateProvinceID { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAddressIDValue { get; set; } = true;

                public bool ShouldSerializeAddressID()
                {
                        return this.ShouldSerializeAddressIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeAddressLine1Value { get; set; } = true;

                public bool ShouldSerializeAddressLine1()
                {
                        return this.ShouldSerializeAddressLine1Value;
                }

                [JsonIgnore]
                public bool ShouldSerializeAddressLine2Value { get; set; } = true;

                public bool ShouldSerializeAddressLine2()
                {
                        return this.ShouldSerializeAddressLine2Value;
                }

                [JsonIgnore]
                public bool ShouldSerializeCityValue { get; set; } = true;

                public bool ShouldSerializeCity()
                {
                        return this.ShouldSerializeCityValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePostalCodeValue { get; set; } = true;

                public bool ShouldSerializePostalCode()
                {
                        return this.ShouldSerializePostalCodeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRowguidValue { get; set; } = true;

                public bool ShouldSerializeRowguid()
                {
                        return this.ShouldSerializeRowguidValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStateProvinceIDValue { get; set; } = true;

                public bool ShouldSerializeStateProvinceID()
                {
                        return this.ShouldSerializeStateProvinceIDValue;
                }

                public void DisableAllFields()
                {
                        this.ShouldSerializeAddressIDValue = false;
                        this.ShouldSerializeAddressLine1Value = false;
                        this.ShouldSerializeAddressLine2Value = false;
                        this.ShouldSerializeCityValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializePostalCodeValue = false;
                        this.ShouldSerializeRowguidValue = false;
                        this.ShouldSerializeStateProvinceIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>8b02f3ddd8a19726a6d3e5c297fd581a</Hash>
</Codenesium>*/