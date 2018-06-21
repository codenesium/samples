using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractBOAdmin : AbstractBusinessObject
        {
                public AbstractBOAdmin()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  string email,
                                                  string firstName,
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
        }
}

/*<Codenesium>
    <Hash>619e9903f4d7d5ffcbadbfb6f5fbb97e</Hash>
</Codenesium>*/