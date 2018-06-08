using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public partial class BOClient: AbstractBusinessObject
        {
                public BOClient() : base()
                {
                }

                public void SetProperties(int id,
                                          string email,
                                          string firstName,
                                          string lastName,
                                          string notes,
                                          string phone)
                {
                        this.Email = email;
                        this.FirstName = firstName;
                        this.Id = id;
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
    <Hash>b4a80b30b9637ae52b5abf2ff2b1372f</Hash>
</Codenesium>*/