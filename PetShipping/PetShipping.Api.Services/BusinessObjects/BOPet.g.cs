using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public partial class BOPet:AbstractBusinessObject
        {
                public BOPet() : base()
                {
                }

                public void SetProperties(int id,
                                          int breedId,
                                          int clientId,
                                          string name,
                                          int weight)
                {
                        this.BreedId = breedId;
                        this.ClientId = clientId;
                        this.Id = id;
                        this.Name = name;
                        this.Weight = weight;
                }

                public int BreedId { get; private set; }

                public int ClientId { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int Weight { get; private set; }
        }
}

/*<Codenesium>
    <Hash>179a5632b6878183b50e82af64067d2c</Hash>
</Codenesium>*/