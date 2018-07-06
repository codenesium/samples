using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiClientResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string email,
                        string firstName,
                        string lastName,
                        string notes,
                        string phone)
                {
                        this.Id = id;
                        this.Email = email;
                        this.FirstName = firstName;
                        this.LastName = lastName;
                        this.Notes = notes;
                        this.Phone = phone;
                }

                public string Email { get; private set; }

                public string FirstName { get; private set; }

                public int Id { get; private set; }

                public string LastName { get; private set; }

                public string Notes { get; private set; }

                public string Phone { get; private set; }
        }
}

/*<Codenesium>
    <Hash>5e87eaa208c6dbb23842470cc4d7f8a4</Hash>
</Codenesium>*/