using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiSpaceXSpaceFeatureRequestModel : AbstractApiRequestModel
        {
                public ApiSpaceXSpaceFeatureRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int spaceFeatureId,
                        int spaceId)
                {
                        this.SpaceFeatureId = spaceFeatureId;
                        this.SpaceId = spaceId;
                }

                [JsonProperty]
                public int SpaceFeatureId { get; private set; }

                [JsonProperty]
                public int SpaceId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8c0a5ae35e4314c399d0df990ad2c798</Hash>
</Codenesium>*/