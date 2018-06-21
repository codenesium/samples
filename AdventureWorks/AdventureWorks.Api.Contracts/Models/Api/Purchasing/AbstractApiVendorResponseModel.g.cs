using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiVendorResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string accountNumber,
                        bool activeFlag,
                        int businessEntityID,
                        int creditRating,
                        DateTime modifiedDate,
                        string name,
                        bool preferredVendorStatus,
                        string purchasingWebServiceURL)
                {
                        this.AccountNumber = accountNumber;
                        this.ActiveFlag = activeFlag;
                        this.BusinessEntityID = businessEntityID;
                        this.CreditRating = creditRating;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.PreferredVendorStatus = preferredVendorStatus;
                        this.PurchasingWebServiceURL = purchasingWebServiceURL;
                }

                public string AccountNumber { get; private set; }

                public bool ActiveFlag { get; private set; }

                public int BusinessEntityID { get; private set; }

                public int CreditRating { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public bool PreferredVendorStatus { get; private set; }

                public string PurchasingWebServiceURL { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAccountNumberValue { get; set; } = true;

                public bool ShouldSerializeAccountNumber()
                {
                        return this.ShouldSerializeAccountNumberValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeActiveFlagValue { get; set; } = true;

                public bool ShouldSerializeActiveFlag()
                {
                        return this.ShouldSerializeActiveFlagValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

                public bool ShouldSerializeBusinessEntityID()
                {
                        return this.ShouldSerializeBusinessEntityIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCreditRatingValue { get; set; } = true;

                public bool ShouldSerializeCreditRating()
                {
                        return this.ShouldSerializeCreditRatingValue;
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
                public bool ShouldSerializePreferredVendorStatusValue { get; set; } = true;

                public bool ShouldSerializePreferredVendorStatus()
                {
                        return this.ShouldSerializePreferredVendorStatusValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePurchasingWebServiceURLValue { get; set; } = true;

                public bool ShouldSerializePurchasingWebServiceURL()
                {
                        return this.ShouldSerializePurchasingWebServiceURLValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAccountNumberValue = false;
                        this.ShouldSerializeActiveFlagValue = false;
                        this.ShouldSerializeBusinessEntityIDValue = false;
                        this.ShouldSerializeCreditRatingValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializePreferredVendorStatusValue = false;
                        this.ShouldSerializePurchasingWebServiceURLValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>b222e7d5a1fe2333a0d3214abdb34d5f</Hash>
</Codenesium>*/