using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiPhoneNumberTypeResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int phoneNumberTypeID,
                        DateTime modifiedDate,
                        string name)
                {
                        this.PhoneNumberTypeID = phoneNumberTypeID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
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

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializePhoneNumberTypeIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>128000cfb396486e3110374b961465f2</Hash>
</Codenesium>*/