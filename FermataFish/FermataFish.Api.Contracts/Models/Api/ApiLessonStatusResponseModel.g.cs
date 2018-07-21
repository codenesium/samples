using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiLessonStatusResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string name,
                        int studioId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.StudioId = studioId;

                        this.IdEntity = nameof(ApiResponse.Studios);
                        this.StudioIdEntity = nameof(ApiResponse.Studios);
                }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [JsonProperty]
                public string IdEntity { get; set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }

                [Required]
                [JsonProperty]
                public int StudioId { get; private set; }

                [JsonProperty]
                public string StudioIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>30850ad0d5e77536d1a5473f1de4ef28</Hash>
</Codenesium>*/