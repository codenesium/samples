using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiBusinessEntityAddressResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int addressID,
                        int addressTypeID,
                        int businessEntityID,
                        DateTime modifiedDate,
                        Guid rowguid)
                {
                        this.AddressID = addressID;
                        this.AddressTypeID = addressTypeID;
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                }

                public int AddressID { get; private set; }

                public int AddressTypeID { get; private set; }

                public int BusinessEntityID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public Guid Rowguid { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAddressIDValue { get; set; } = true;

                public bool ShouldSerializeAddressID()
                {
                        return this.ShouldSerializeAddressIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeAddressTypeIDValue { get; set; } = true;

                public bool ShouldSerializeAddressTypeID()
                {
                        return this.ShouldSerializeAddressTypeIDValue;
                }

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
                public bool ShouldSerializeRowguidValue { get; set; } = true;

                public bool ShouldSerializeRowguid()
                {
                        return this.ShouldSerializeRowguidValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAddressIDValue = false;
                        this.ShouldSerializeAddressTypeIDValue = false;
                        this.ShouldSerializeBusinessEntityIDValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeRowguidValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>e6862290a87fdfedc920fbfae51bd460</Hash>
</Codenesium>*/