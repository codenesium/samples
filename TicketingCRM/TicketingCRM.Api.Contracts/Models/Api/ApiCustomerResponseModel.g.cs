using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public class ApiCustomerResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string email,
                        string firstName,
                        int id,
                        string lastName,
                        string phone)
                {
                        this.Email = email;
                        this.FirstName = firstName;
                        this.Id = id;
                        this.LastName = lastName;
                        this.Phone = phone;
                }

                public string Email { get; private set; }

                public string FirstName { get; private set; }

                public int Id { get; private set; }

                public string LastName { get; private set; }

                public string Phone { get; private set; }

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
                        this.ShouldSerializeEmailValue = false;
                        this.ShouldSerializeFirstNameValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeLastNameValue = false;
                        this.ShouldSerializePhoneValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>3f3c6cb7cd69258afa8502fc71a80038</Hash>
</Codenesium>*/