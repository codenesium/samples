using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiAdminResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string email,
                        string firstName,
                        int id,
                        string lastName,
                        string password,
                        string phone,
                        string username)
                {
                        this.Email = email;
                        this.FirstName = firstName;
                        this.Id = id;
                        this.LastName = lastName;
                        this.Password = password;
                        this.Phone = phone;
                        this.Username = username;
                }

                public string Email { get; private set; }

                public string FirstName { get; private set; }

                public int Id { get; private set; }

                public string LastName { get; private set; }

                public string Password { get; private set; }

                public string Phone { get; private set; }

                public string Username { get; private set; }

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
                public bool ShouldSerializePasswordValue { get; set; } = true;

                public bool ShouldSerializePassword()
                {
                        return this.ShouldSerializePasswordValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePhoneValue { get; set; } = true;

                public bool ShouldSerializePhone()
                {
                        return this.ShouldSerializePhoneValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeUsernameValue { get; set; } = true;

                public bool ShouldSerializeUsername()
                {
                        return this.ShouldSerializeUsernameValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeEmailValue = false;
                        this.ShouldSerializeFirstNameValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeLastNameValue = false;
                        this.ShouldSerializePasswordValue = false;
                        this.ShouldSerializePhoneValue = false;
                        this.ShouldSerializeUsernameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>3b901ba16d98fb0869820f9ca8a78d4a</Hash>
</Codenesium>*/