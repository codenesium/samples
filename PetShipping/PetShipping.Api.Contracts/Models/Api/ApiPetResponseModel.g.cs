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

                [Required]
                [JsonProperty]
                public int BreedId { get; private set; }

                [JsonProperty]
                public string BreedIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public int ClientId { get; private set; }

                [JsonProperty]
                public string ClientIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }

                [Required]
                [JsonProperty]
                public int Weight { get; private set; }
        }
}

/*<Codenesium>
    <Hash>ffc65dc35e4932ea0992cd67cb55b438</Hash>
</Codenesium>*/