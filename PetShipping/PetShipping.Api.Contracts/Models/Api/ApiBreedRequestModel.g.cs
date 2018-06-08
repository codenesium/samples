using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiBreedRequestModel: AbstractApiRequestModel
        {
                public ApiBreedRequestModel() : base()
                {
                }

                public void SetProperties(
                        string name,
                        int speciesId)
                {
                        this.Name = name;
                        this.SpeciesId = speciesId;
                }

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
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
    <Hash>2077c9c3d3dd7c2672b6bf656fbe2da1</Hash>
</Codenesium>*/