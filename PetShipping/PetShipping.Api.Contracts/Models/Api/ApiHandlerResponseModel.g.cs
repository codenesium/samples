using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public class ApiHandlerResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int countryId,
                        string email,
                        string firstName,
                        int id,
                        string lastName,
                        string phone)
                {
                        this.CountryId = countryId;
                        this.Email = email;
                        this.FirstName = firstName;
                        this.Id = id;
                        this.LastName = lastName;
                        this.Phone = phone;
                }

                public int CountryId { get; private set; }

                public string Email { get; private set; }

                public string FirstName { get; private set; }

                public int Id { get; private set; }

                public string LastName { get; private set; }

                public string Phone { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeCountryIdValue { get; set; } = true;

                public bool ShouldSerializeCountryId()
                {
                        return this.ShouldSerializeCountryIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeEmailValue { get; set; } = true;

                public bool ShouldSerializeEmail()
                {
                        return this.ShouldSerializeEmailValue;
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
                public bool ShouldSerializePhoneValue { get; set; } = true;

                public bool ShouldSerializePhone()
                {
                        return this.ShouldSerializePhoneValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCountryIdValue = false;
                        this.ShouldSerializeEmailValue = false;
                        this.ShouldSerializeFirstNameValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeLastNameValue = false;
                        this.ShouldSerializePhoneValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>0f1f45ca1d79ff3321c92d5ccd7195b5</Hash>
</Codenesium>*/