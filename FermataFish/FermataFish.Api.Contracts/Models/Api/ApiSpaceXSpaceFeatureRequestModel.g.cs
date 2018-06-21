using Codenesium.DataConversionExtensions;
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

                public void SetProperties(
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
    <Hash>dc37ecc7b5429ea18919a471e6fe55c7</Hash>
</Codenesium>*/