using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiCustomerResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string email,
                        string firstName,
                        string lastName,
                        string phone)
                {
                        this.Id = id;
                        this.Email = email;
                        this.FirstName = firstName;
                        this.LastName = lastName;
                        this.Phone = phone;
                }

                public string Email { get; private set; }

                public string FirstName { get; private set; }

                public int Id { get; private set; }

                public string LastName { get; private set; }

                public string Phone { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1064348a7bb81264d1360702567b9b02</Hash>
</Codenesium>*/