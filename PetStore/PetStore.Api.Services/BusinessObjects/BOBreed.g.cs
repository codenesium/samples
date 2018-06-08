using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Services
{
        public partial class BOBreed: AbstractBusinessObject
        {
                public BOBreed() : base()
                {
                }

                public void SetProperties(int id,
                                          string name)
                {
                        this.Id = id;
                        this.Name = name;
                }

                public int Id { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>13f950cf2bdf5edf5af7959ce876dd8c</Hash>
</Codenesium>*/