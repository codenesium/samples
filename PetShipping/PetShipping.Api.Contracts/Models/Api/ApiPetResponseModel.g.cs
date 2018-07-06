using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPetResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int breedId,
                        int clientId,
                        string name,
                        int weight)
                {
                        this.Id = id;
                        this.BreedId = breedId;
                        this.ClientId = clientId;
                        this.Name = name;
                        this.Weight = weight;

                        this.BreedIdEntity = nameof(ApiResponse.Breeds);
                        this.ClientIdEntity = nameof(ApiResponse.Clients);
                }

                public int BreedId { get; private set; }

                public string BreedIdEntity { get; set; }

                public int ClientId { get; private set; }

                public string ClientIdEntity { get; set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int Weight { get; private set; }
        }
}

/*<Codenesium>
    <Hash>ecb0fd77b76068c2696a8b8a55edfcc2</Hash>
</Codenesium>*/