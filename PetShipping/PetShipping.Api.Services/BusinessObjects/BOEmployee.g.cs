using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public partial class BOEmployee: AbstractBusinessObject
        {
                public BOEmployee() : base()
                {
                }

                public void SetProperties(int id,
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
    <Hash>7ee3f5d6b1de8cd082f706f3c106062f</Hash>
</Codenesium>*/