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

                private int spaceFeatureId;

                [Required]
                public int SpaceFeatureId
                {
                        get
                        {
                                return this.spaceFeatureId;
                        }

                        set
                        {
                                this.spaceFeatureId = value;
                        }
                }

                private int spaceId;

                [Required]
                public int SpaceId
                {
                        get
                        {
                                return this.spaceId;
                        }

                        set
                        {
                                this.spaceId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>e0b8d14b09862f6fe02241c4753b5e6a</Hash>
</Codenesium>*/