using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiBreedResponseModel : AbstractApiResponseModel
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
        }
}

/*<Codenesium>
    <Hash>9a729e084a7d8026408c7ff5ceedf629</Hash>
</Codenesium>*/