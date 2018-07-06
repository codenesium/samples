using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiSpaceXSpaceFeatureResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int spaceFeatureId,
                        int spaceId)
                {
                        this.Id = id;
                        this.SpaceFeatureId = spaceFeatureId;
                        this.SpaceId = spaceId;

                        this.SpaceFeatureIdEntity = nameof(ApiResponse.SpaceFeatures);
                        this.SpaceIdEntity = nameof(ApiResponse.Spaces);
                }

                public int Id { get; private set; }

                public int SpaceFeatureId { get; private set; }

                public string SpaceFeatureIdEntity { get; set; }

                public int SpaceId { get; private set; }

                public string SpaceIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>4553331ae527fb5b80607bb671cba4ff</Hash>
</Codenesium>*/