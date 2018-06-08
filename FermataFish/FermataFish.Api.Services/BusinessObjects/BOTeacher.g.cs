using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public partial class BOTeacher: AbstractBusinessObject
        {
                public BOTeacher() : base()
                {
                }

                public void SetProperties(int id,
                                          DateTime birthday,
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

                public DateTime Birthday { get; private set; }

                public string Email { get; private set; }

                public string FirstName { get; private set; }

                public int Id { get; private set; }

                public string LastName { get; private set; }

                public string Phone { get; private set; }

                public int StudioId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>f1615b13e8238d012c6b05f9ae2f03b8</Hash>
</Codenesium>*/