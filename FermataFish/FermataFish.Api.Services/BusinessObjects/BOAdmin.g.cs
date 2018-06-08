using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public partial class BOAdmin: AbstractBusinessObject
        {
                public BOAdmin() : base()
                {
                }

                public void SetProperties(int id,
                                          Nullable<DateTime> birthday,
                                          string email,
                                          string firstName,
                                          string lastName,
                                          string phone,
                                          int studioId)
                {
                        this.Birthday = birthday;
                        this.Email = email;
                        this.FirstName = firstName;
                        this.Id = id;
                        this.LastName = lastName;
                        this.Phone = phone;
                        this.StudioId = studioId;
                }

                public Nullable<DateTime> Birthday { get; private set; }

                public string Email { get; private set; }

                public string FirstName { get; private set; }

                public int Id { get; private set; }

                public string LastName { get; private set; }

                public string Phone { get; private set; }

                public int StudioId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>5bef836674e95d3be57846568b5d5717</Hash>
</Codenesium>*/