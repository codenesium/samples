using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiCustomerRequestModel : AbstractApiRequestModel
        {
                public ApiCustomerRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string email,
                        string firstName,
                        string lastName,
                        string phone)
                {
                        this.Email = email;
                        this.FirstName = firstName;
                        this.LastName = lastName;
                        this.Phone = phone;
                }

                [JsonProperty]
                public string Email { get; private set; }

                [JsonProperty]
                public string FirstName { get; private set; }

                [JsonProperty]
                public string LastName { get; private set; }

                [JsonProperty]
                public string Phone { get; private set; }
        }
}

/*<Codenesium>
    <Hash>be24e96eaadd0bfa4f91399e13f7cdd6</Hash>
</Codenesium>*/