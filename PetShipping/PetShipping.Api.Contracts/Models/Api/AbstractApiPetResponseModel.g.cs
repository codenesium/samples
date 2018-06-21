using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiPetResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int breedId,
                        int clientId,
                        int id,
                        string name,
                        int weight)
                {
                        this.BreedId = breedId;
                        this.ClientId = clientId;
                        this.Id = id;
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

                [JsonIgnore]
                public bool ShouldSerializeBreedIdValue { get; set; } = true;

                public bool ShouldSerializeBreedId()
                {
                        return this.ShouldSerializeBreedIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeClientIdValue { get; set; } = true;

                public bool ShouldSerializeClientId()
                {
                        return this.ShouldSerializeClientIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeWeightValue { get; set; } = true;

                public bool ShouldSerializeWeight()
                {
                        return this.ShouldSerializeWeightValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeBreedIdValue = false;
                        this.ShouldSerializeClientIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeWeightValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>89573bb3344aaee2f1d449824caca8df</Hash>
</Codenesium>*/