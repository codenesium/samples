using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiSpaceXSpaceFeatureResponseModel : AbstractApiResponseModel
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

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSpaceFeatureIdValue { get; set; } = true;

                public bool ShouldSerializeSpaceFeatureId()
                {
                        return this.ShouldSerializeSpaceFeatureIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSpaceIdValue { get; set; } = true;

                public bool ShouldSerializeSpaceId()
                {
                        return this.ShouldSerializeSpaceIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeSpaceFeatureIdValue = false;
                        this.ShouldSerializeSpaceIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>8d7221d4b6def374937f58d2d4753d72</Hash>
</Codenesium>*/