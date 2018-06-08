using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public partial class BOBreed: AbstractBusinessObject
        {
                public BOBreed() : base()
                {
                }

                public void SetProperties(int id,
                                          string name,
                                          int speciesId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.SpeciesId = speciesId;
                }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int SpeciesId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e3b5d39b8781dfc1e06be1745a31d28a</Hash>
</Codenesium>*/