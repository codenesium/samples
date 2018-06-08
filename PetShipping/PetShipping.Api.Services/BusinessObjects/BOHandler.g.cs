using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public partial class BOHandler: AbstractBusinessObject
        {
                public BOHandler() : base()
                {
                }

                public void SetProperties(int id,
                                          int countryId,
                                          string email,
                                          string firstName,
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
        }
}

/*<Codenesium>
    <Hash>3de40c8d1cced5d0c11b3f319547121d</Hash>
</Codenesium>*/