using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiBusinessEntityAddressResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int businessEntityID,
                        int addressID,
                        int addressTypeID,
                        DateTime modifiedDate,
                        Guid rowguid)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.AddressID = addressID;
                        this.AddressTypeID = addressTypeID;
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
    <Hash>63cc7a5d51d581c3f2b969b94725cc51</Hash>
</Codenesium>*/