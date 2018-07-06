using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiSpaceResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string description,
                        string name,
                        int studioId)
                {
                        this.Id = id;
                        this.Description = description;
                        this.Name = name;
                        this.StudioId = studioId;

                        this.StudioIdEntity = nameof(ApiResponse.Studios);
                }

                public string Description { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int StudioId { get; private set; }

                public string StudioIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>f955c20da8393c6449da2095053e44e0</Hash>
</Codenesium>*/