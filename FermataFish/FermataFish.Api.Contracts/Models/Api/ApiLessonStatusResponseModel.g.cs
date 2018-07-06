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

                public int Id { get; private set; }

                public string IdEntity { get; set; }

                public string Name { get; private set; }

                public int StudioId { get; private set; }

                public string StudioIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>2dfe184ac218a0f7ea1b37a7ed45d4df</Hash>
</Codenesium>*/