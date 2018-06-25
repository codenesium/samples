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
    <Hash>56f413b3283c18c01540fcc2109a9e84</Hash>
</Codenesium>*/