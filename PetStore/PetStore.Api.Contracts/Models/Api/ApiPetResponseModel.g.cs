using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace PetStoreNS.Api.Contracts
{
        public partial class ApiPetResponseModel: AbstractApiResponseModel
        {
                public ApiPetResponseModel() : base()
                {
                }

                public void SetProperties(
                        DateTime acquiredDate,
                        int breedId,
                        string description,
                        int id,
                        int penId,
                        decimal price,
                        int speciesId)
                {
                        this.AcquiredDate = acquiredDate;
                        this.BreedId = breedId;
                        this.Description = description;
                        this.Id = id;
                        this.PenId = penId;
                        this.Price = price;
                        this.SpeciesId = speciesId;

                        this.BreedIdEntity = nameof(ApiResponse.Breeds);
                        this.PenIdEntity = nameof(ApiResponse.Pens);
                        this.SpeciesIdEntity = nameof(ApiResponse.Species);
                }

                public DateTime AcquiredDate { get; private set; }

                public int BreedId { get; private set; }

                public string BreedIdEntity { get; set; }

                public string Description { get; private set; }

                public int Id { get; private set; }

                public int PenId { get; private set; }

                public string PenIdEntity { get; set; }

                public decimal Price { get; private set; }

                public int SpeciesId { get; private set; }

                public string SpeciesIdEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeAcquiredDateValue { get; set; } = true;

                public bool ShouldSerializeAcquiredDate()
                {
                        return this.ShouldSerializeAcquiredDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeBreedIdValue { get; set; } = true;

                public bool ShouldSerializeBreedId()
                {
                        return this.ShouldSerializeBreedIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDescriptionValue { get; set; } = true;

                public bool ShouldSerializeDescription()
                {
                        return this.ShouldSerializeDescriptionValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePenIdValue { get; set; } = true;

                public bool ShouldSerializePenId()
                {
                        return this.ShouldSerializePenIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePriceValue { get; set; } = true;

                public bool ShouldSerializePrice()
                {
                        return this.ShouldSerializePriceValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSpeciesIdValue { get; set; } = true;

                public bool ShouldSerializeSpeciesId()
                {
                        return this.ShouldSerializeSpeciesIdValue;
                }

                public void DisableAllFields()
                {
                        this.ShouldSerializeAcquiredDateValue = false;
                        this.ShouldSerializeBreedIdValue = false;
                        this.ShouldSerializeDescriptionValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializePenIdValue = false;
                        this.ShouldSerializePriceValue = false;
                        this.ShouldSerializeSpeciesIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>82543b434879f54209d1037c60cda7cf</Hash>
</Codenesium>*/