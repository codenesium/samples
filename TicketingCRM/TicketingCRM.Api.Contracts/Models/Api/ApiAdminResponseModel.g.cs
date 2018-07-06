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

                public string Email { get; private set; }

                public string FirstName { get; private set; }

                public int Id { get; private set; }

                public string LastName { get; private set; }

                public string Password { get; private set; }

                public string Phone { get; private set; }

                public string Username { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c0d22422d9059626cf1c0c06b04d5f59</Hash>
</Codenesium>*/