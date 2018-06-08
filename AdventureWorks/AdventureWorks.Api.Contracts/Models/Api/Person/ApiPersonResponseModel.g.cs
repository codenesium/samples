using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiPersonResponseModel: AbstractApiResponseModel
        {
                public ApiPersonResponseModel() : base()
                {
                }

                public void SetProperties(
                        string additionalContactInfo,
                        int businessEntityID,
                        string demographics,
                        int emailPromotion,
                        string firstName,
                        string lastName,
                        string middleName,
                        DateTime modifiedDate,
                        bool nameStyle,
                        string personType,
                        Guid rowguid,
                        string suffix,
                        string title)
                {
                        this.AdditionalContactInfo = additionalContactInfo;
                        this.BusinessEntityID = businessEntityID;
                        this.Demographics = demographics;
                        this.EmailPromotion = emailPromotion;
                        this.FirstName = firstName;
                        this.LastName = lastName;
                        this.MiddleName = middleName;
                        this.ModifiedDate = modifiedDate;
                        this.NameStyle = nameStyle;
                        this.PersonType = personType;
                        this.Rowguid = rowguid;
                        this.Suffix = suffix;
                        this.Title = title;
                }

                public string AdditionalContactInfo { get; private set; }

                public int BusinessEntityID { get; private set; }

                public string Demographics { get; private set; }

                public int EmailPromotion { get; private set; }

                public string FirstName { get; private set; }

                public string LastName { get; private set; }

                public string MiddleName { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public bool NameStyle { get; private set; }

                public string PersonType { get; private set; }

                public Guid Rowguid { get; private set; }

                public string Suffix { get; private set; }

                public string Title { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAdditionalContactInfoValue { get; set; } = true;

                public bool ShouldSerializeAdditionalContactInfo()
                {
                        return this.ShouldSerializeAdditionalContactInfoValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

                public bool ShouldSerializeBusinessEntityID()
                {
                        return this.ShouldSerializeBusinessEntityIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDemographicsValue { get; set; } = true;

                public bool ShouldSerializeDemographics()
                {
                        return this.ShouldSerializeDemographicsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeEmailPromotionValue { get; set; } = true;

                public bool ShouldSerializeEmailPromotion()
                {
                        return this.ShouldSerializeEmailPromotionValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeFirstNameValue { get; set; } = true;

                public bool ShouldSerializeFirstName()
                {
                        return this.ShouldSerializeFirstNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLastNameValue { get; set; } = true;

                public bool ShouldSerializeLastName()
                {
                        return this.ShouldSerializeLastNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeMiddleNameValue { get; set; } = true;

                public bool ShouldSerializeMiddleName()
                {
                        return this.ShouldSerializeMiddleNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameStyleValue { get; set; } = true;

                public bool ShouldSerializeNameStyle()
                {
                        return this.ShouldSerializeNameStyleValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePersonTypeValue { get; set; } = true;

                public bool ShouldSerializePersonType()
                {
                        return this.ShouldSerializePersonTypeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRowguidValue { get; set; } = true;

                public bool ShouldSerializeRowguid()
                {
                        return this.ShouldSerializeRowguidValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSuffixValue { get; set; } = true;

                public bool ShouldSerializeSuffix()
                {
                        return this.ShouldSerializeSuffixValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTitleValue { get; set; } = true;

                public bool ShouldSerializeTitle()
                {
                        return this.ShouldSerializeTitleValue;
                }

                public void DisableAllFields()
                {
                        this.ShouldSerializeAdditionalContactInfoValue = false;
                        this.ShouldSerializeBusinessEntityIDValue = false;
                        this.ShouldSerializeDemographicsValue = false;
                        this.ShouldSerializeEmailPromotionValue = false;
                        this.ShouldSerializeFirstNameValue = false;
                        this.ShouldSerializeLastNameValue = false;
                        this.ShouldSerializeMiddleNameValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameStyleValue = false;
                        this.ShouldSerializePersonTypeValue = false;
                        this.ShouldSerializeRowguidValue = false;
                        this.ShouldSerializeSuffixValue = false;
                        this.ShouldSerializeTitleValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>243dec71723be6750be1e0885f027c4d</Hash>
</Codenesium>*/