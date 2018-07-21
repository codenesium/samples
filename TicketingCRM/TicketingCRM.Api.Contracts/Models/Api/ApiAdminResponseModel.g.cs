using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiAdminResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string email,
                        string firstName,
                        string lastName,
                        string password,
                        string phone,
                        string username)
                {
                        this.Id = id;
                        this.Email = email;
                        this.FirstName = firstName;
                        this.LastName = lastName;
                        this.Password = password;
                        this.Phone = phone;
                        this.Username = username;
                }

                [Required]
                [JsonProperty]
                public string Email { get; private set; }

                [Required]
                [JsonProperty]
                public string FirstName { get; private set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string LastName { get; private set; }

                [Required]
                [JsonProperty]
                public string Password { get; private set; }

                [Required]
                [JsonProperty]
                public string Phone { get; private set; }

                [Required]
                [JsonProperty]
                public string Username { get; private set; }
        }
}

/*<Codenesium>
    <Hash>62fa0f7523fae245c0e54d151adff11d</Hash>
</Codenesium>*/