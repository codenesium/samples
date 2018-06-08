using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiEmailAddressResponseModel: AbstractApiResponseModel
        {
                public ApiEmailAddressResponseModel() : base()
                {
                }

                public void SetProperties(
                        int businessEntityID,
                        string emailAddress1,
                        int emailAddressID,
                        DateTime modifiedDate,
                        Guid rowguid)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.EmailAddress1 = emailAddress1;
                        this.EmailAddressID = emailAddressID;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                }

                public int BusinessEntityID { get; private set; }

                public string EmailAddress1 { get; private set; }

                public int EmailAddressID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public Guid Rowguid { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

                public bool ShouldSerializeBusinessEntityID()
                {
                        return this.ShouldSerializeBusinessEntityIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeEmailAddress1Value { get; set; } = true;

                public bool ShouldSerializeEmailAddress1()
                {
                        return this.ShouldSerializeEmailAddress1Value;
                }

                [JsonIgnore]
                public bool ShouldSerializeEmailAddressIDValue { get; set; } = true;

                public bool ShouldSerializeEmailAddressID()
                {
                        return this.ShouldSerializeEmailAddressIDValue;
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

                public void DisableAllFields()
                {
                        this.ShouldSerializeBusinessEntityIDValue = false;
                        this.ShouldSerializeEmailAddress1Value = false;
                        this.ShouldSerializeEmailAddressIDValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeRowguidValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>e610316796d9a7cfca7ab87f8dbc439e</Hash>
</Codenesium>*/