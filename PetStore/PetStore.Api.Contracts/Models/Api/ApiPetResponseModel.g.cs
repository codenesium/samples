using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Contracts
{
        public partial class ApiPetResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        DateTime acquiredDate,
                        int breedId,
                        string description,
                        int penId,
                        decimal price,
                        int speciesId)
                {
                        this.Id = id;
                        this.AcquiredDate = acquiredDate;
                        this.BreedId = breedId;
                        this.Description = description;
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
        }
}

/*<Codenesium>
    <Hash>b65b10d5f053672ecfc17833657ac1f2</Hash>
</Codenesium>*/