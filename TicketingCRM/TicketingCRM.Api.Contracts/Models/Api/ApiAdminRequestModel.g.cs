using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiAdminRequestModel : AbstractApiRequestModel
        {
                public ApiAdminRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string email,
                        string firstName,
                        string lastName,
                        string password,
                        string phone,
                        string username)
                {
                        this.Email = email;
                        this.FirstName = firstName;
                        this.LastName = lastName;
                        this.Password = password;
                        this.Phone = phone;
                        this.Username = username;
                }

                [JsonProperty]
                public string Email { get; private set; }

                [JsonProperty]
                public string FirstName { get; private set; }

                [JsonProperty]
                public string LastName { get; private set; }

                [JsonProperty]
                public string Password { get; private set; }

                [JsonProperty]
                public string Phone { get; private set; }

                [JsonProperty]
                public string Username { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c5dd72520dd39fd081bcd7c0af6e4e21</Hash>
</Codenesium>*/