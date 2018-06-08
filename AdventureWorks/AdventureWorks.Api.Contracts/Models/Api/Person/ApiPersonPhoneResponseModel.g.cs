using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiPersonPhoneResponseModel: AbstractApiResponseModel
        {
                public ApiPersonPhoneResponseModel() : base()
                {
                }

                public void SetProperties(
                        int businessEntityID,
                        DateTime modifiedDate,
                        string phoneNumber,
                        int phoneNumberTypeID)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.PhoneNumber = phoneNumber;
                        this.PhoneNumberTypeID = phoneNumberTypeID;
                }

                public int BusinessEntityID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string PhoneNumber { get; private set; }

                public int PhoneNumberTypeID { get; private set; }

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
                public bool ShouldSerializePhoneNumberValue { get; set; } = true;

                public bool ShouldSerializePhoneNumber()
                {
                        return this.ShouldSerializePhoneNumberValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePhoneNumberTypeIDValue { get; set; } = true;

                public bool ShouldSerializePhoneNumberTypeID()
                {
                        return this.ShouldSerializePhoneNumberTypeIDValue;
                }

                public void DisableAllFields()
                {
                        this.ShouldSerializeBusinessEntityIDValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializePhoneNumberValue = false;
                        this.ShouldSerializePhoneNumberTypeIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>39403d9167a956677ec360f7e7468893</Hash>
</Codenesium>*/