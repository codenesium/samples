using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace PetStoreNS.Api.Contracts
{
        public partial class ApiPetRequestModel: AbstractApiRequestModel
        {
                public ApiPetRequestModel() : base()
                {
                }

                public void SetProperties(
                        DateTime acquiredDate,
                        int breedId,
                        string description,
                        int penId,
                        decimal price,
                        int speciesId)
                {
                        this.AcquiredDate = acquiredDate;
                        this.BreedId = breedId;
                        this.Description = description;
                        this.PenId = penId;
                        this.Price = price;
                        this.SpeciesId = speciesId;
                }

                private DateTime acquiredDate;

                [Required]
                public DateTime AcquiredDate
                {
                        get
                        {
                                return this.acquiredDate;
                        }

                        set
                        {
                                this.acquiredDate = value;
                        }
                }

                private int breedId;

                [Required]
                public int BreedId
                {
                        get
                        {
                                return this.breedId;
                        }

                        set
                        {
                                this.breedId = value;
                        }
                }

                private string description;

                [Required]
                public string Description
                {
                        get
                        {
                                return this.description;
                        }

                        set
                        {
                                this.description = value;
                        }
                }

                private int penId;

                [Required]
                public int PenId
                {
                        get
                        {
                                return this.penId;
                        }

                        set
                        {
                                this.penId = value;
                        }
                }

                private decimal price;

                [Required]
                public decimal Price
                {
                        get
                        {
                                return this.price;
                        }

                        set
                        {
                                this.price = value;
                        }
                }

                private int speciesId;

                [Required]
                public int SpeciesId
                {
                        get
                        {
                                return this.speciesId;
                        }

                        set
                        {
                                this.speciesId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>6c1ffdbd8c9f38fc845e1e4f5b69be79</Hash>
</Codenesium>*/