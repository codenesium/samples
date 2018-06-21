using Codenesium.DataConversionExtensions;
using System;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractBOTeacher : AbstractBusinessObject
        {
                public AbstractBOTeacher()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
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
    <Hash>44b07d7491f3e86f4c18276da3ae7f1b</Hash>
</Codenesium>*/