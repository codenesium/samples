using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiSpaceXSpaceFeatureRequestModel: AbstractApiRequestModel
        {
                public ApiSpaceXSpaceFeatureRequestModel() : base()
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
    <Hash>c356fbdbad01bb11f0a369990ab8566b</Hash>
</Codenesium>*/