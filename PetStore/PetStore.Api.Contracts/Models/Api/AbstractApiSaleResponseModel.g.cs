using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace PetStoreNS.Api.Contracts
{
        public abstract class AbstractApiSaleResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        decimal amount,
                        string firstName,
                        int id,
                        string lastName,
                        int paymentTypeId,
                        int petId,
                        string phone)
                {
                        this.Amount = amount;
                        this.FirstName = firstName;
                        this.Id = id;
                        this.LastName = lastName;
                        this.PaymentTypeId = paymentTypeId;
                        this.PetId = petId;
                        this.Phone = phone;

                        this.PaymentTypeIdEntity = nameof(ApiResponse.PaymentTypes);
                        this.PetIdEntity = nameof(ApiResponse.Pets);
                }

                public decimal Amount { get; private set; }

                public string FirstName { get; private set; }

                public int Id { get; private set; }

                public string LastName { get; private set; }

                public int PaymentTypeId { get; private set; }

                public string PaymentTypeIdEntity { get; set; }

                public int PetId { get; private set; }

                public string PetIdEntity { get; set; }

                public string Phone { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAmountValue { get; set; } = true;

                public bool ShouldSerializeAmount()
                {
                        return this.ShouldSerializeAmountValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeFirstNameValue { get; set; } = true;

                public bool ShouldSerializeFirstName()
                {
                        return this.ShouldSerializeFirstNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLastNameValue { get; set; } = true;

                public bool ShouldSerializeLastName()
                {
                        return this.ShouldSerializeLastNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePaymentTypeIdValue { get; set; } = true;

                public bool ShouldSerializePaymentTypeId()
                {
                        return this.ShouldSerializePaymentTypeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePetIdValue { get; set; } = true;

                public bool ShouldSerializePetId()
                {
                        return this.ShouldSerializePetIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePhoneValue { get; set; } = true;

                public bool ShouldSerializePhone()
                {
                        return this.ShouldSerializePhoneValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAmountValue = false;
                        this.ShouldSerializeFirstNameValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeLastNameValue = false;
                        this.ShouldSerializePaymentTypeIdValue = false;
                        this.ShouldSerializePetIdValue = false;
                        this.ShouldSerializePhoneValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>1c69a86171208497e3e9cb3e0220cdd0</Hash>
</Codenesium>*/