using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public partial class BOCustomer: AbstractBusinessObject
        {
                public BOCustomer() : base()
                {
                }

                public void SetProperties(int id,
                                          string email,
                                          string firstName,
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
        }
}

/*<Codenesium>
    <Hash>5c3dd38b4393039cf1fa6dc75e8fe8fc</Hash>
</Codenesium>*/