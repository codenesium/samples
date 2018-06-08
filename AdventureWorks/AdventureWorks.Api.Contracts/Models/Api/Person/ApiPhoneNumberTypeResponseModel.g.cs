using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiPhoneNumberTypeResponseModel: AbstractApiResponseModel
        {
                public ApiPhoneNumberTypeResponseModel() : base()
                {
                }

                public void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        int phoneNumberTypeID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.PhoneNumberTypeID = phoneNumberTypeID;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public int PhoneNumberTypeID { get; private set; }

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
                public bool ShouldSerializePhoneNumberTypeIDValue { get; set; } = true;

                public bool ShouldSerializePhoneNumberTypeID()
                {
                        return this.ShouldSerializePhoneNumberTypeIDValue;
                }

                public void DisableAllFields()
                {
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializePhoneNumberTypeIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>14404c5f60a37fcb1fb51c6767ff5c7c</Hash>
</Codenesium>*/