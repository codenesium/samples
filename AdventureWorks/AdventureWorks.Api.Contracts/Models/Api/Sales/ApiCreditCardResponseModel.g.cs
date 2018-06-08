using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiCreditCardResponseModel: AbstractApiResponseModel
        {
                public ApiCreditCardResponseModel() : base()
                {
                }

                public void SetProperties(
                        string cardNumber,
                        string cardType,
                        int creditCardID,
                        int expMonth,
                        short expYear,
                        DateTime modifiedDate)
                {
                        this.CardNumber = cardNumber;
                        this.CardType = cardType;
                        this.CreditCardID = creditCardID;
                        this.ExpMonth = expMonth;
                        this.ExpYear = expYear;
                        this.ModifiedDate = modifiedDate;
                }

                public string CardNumber { get; private set; }

                public string CardType { get; private set; }

                public int CreditCardID { get; private set; }

                public int ExpMonth { get; private set; }

                public short ExpYear { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeCardNumberValue { get; set; } = true;

                public bool ShouldSerializeCardNumber()
                {
                        return this.ShouldSerializeCardNumberValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCardTypeValue { get; set; } = true;

                public bool ShouldSerializeCardType()
                {
                        return this.ShouldSerializeCardTypeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCreditCardIDValue { get; set; } = true;

                public bool ShouldSerializeCreditCardID()
                {
                        return this.ShouldSerializeCreditCardIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeExpMonthValue { get; set; } = true;

                public bool ShouldSerializeExpMonth()
                {
                        return this.ShouldSerializeExpMonthValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeExpYearValue { get; set; } = true;

                public bool ShouldSerializeExpYear()
                {
                        return this.ShouldSerializeExpYearValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                public void DisableAllFields()
                {
                        this.ShouldSerializeCardNumberValue = false;
                        this.ShouldSerializeCardTypeValue = false;
                        this.ShouldSerializeCreditCardIDValue = false;
                        this.ShouldSerializeExpMonthValue = false;
                        this.ShouldSerializeExpYearValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>155a824bd52f454c7e3fb1bbe9da9b39</Hash>
</Codenesium>*/