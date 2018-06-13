using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiAddressTypeResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int addressTypeID,
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid)
                {
                        this.AddressTypeID = addressTypeID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                }

                public int AddressTypeID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public Guid Rowguid { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAddressTypeIDValue { get; set; } = true;

                public bool ShouldSerializeAddressTypeID()
                {
                        return this.ShouldSerializeAddressTypeIDValue;
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

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAddressTypeIDValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeRowguidValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>c40c96f388aff7638d46473e4d5c9e3f</Hash>
</Codenesium>*/