using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractBOEmployee: AbstractBusinessObject
        {
                public AbstractBOEmployee() : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  string firstName,
                                                  bool isSalesPerson,
                                                  bool isShipper,
                                                  string lastName)
                {
                        this.FirstName = firstName;
                        this.Id = id;
                        this.IsSalesPerson = isSalesPerson;
                        this.IsShipper = isShipper;
                        this.LastName = lastName;
                }

                public string FirstName { get; private set; }

                public int Id { get; private set; }

                public bool IsSalesPerson { get; private set; }

                public bool IsShipper { get; private set; }

                public string LastName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>248ada8467a0c00c1c74c4a8aa802045</Hash>
</Codenesium>*/