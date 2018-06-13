using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiBreedResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string name,
                        int speciesId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.SpeciesId = speciesId;

                        this.SpeciesIdEntity = nameof(ApiResponse.Species);
                }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int SpeciesId { get; private set; }

                public string SpeciesIdEntity { get; set; }

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
                public bool ShouldSerializeSpeciesIdValue { get; set; } = true;

                public bool ShouldSerializeSpeciesId()
                {
                        return this.ShouldSerializeSpeciesIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeSpeciesIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>f8f959e5a96f8e4893ee3a63a8a34217</Hash>
</Codenesium>*/