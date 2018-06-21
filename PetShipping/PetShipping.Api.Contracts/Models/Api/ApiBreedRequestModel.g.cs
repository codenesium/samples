using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiBreedRequestModel : AbstractApiRequestModel
        {
                public ApiBreedRequestModel()
                        : base()
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
    <Hash>9a20886a583ac53b3bbc50477d0f5574</Hash>
</Codenesium>*/