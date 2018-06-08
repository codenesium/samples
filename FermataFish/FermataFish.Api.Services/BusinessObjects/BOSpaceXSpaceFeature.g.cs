using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public partial class BOSpaceXSpaceFeature: AbstractBusinessObject
        {
                public BOSpaceXSpaceFeature() : base()
                {
                }

                public void SetProperties(int id,
                                          int spaceFeatureId,
                                          int spaceId)
                {
                        this.Id = id;
                        this.SpaceFeatureId = spaceFeatureId;
                        this.SpaceId = spaceId;
                }

                public int Id { get; private set; }

                public int SpaceFeatureId { get; private set; }

                public int SpaceId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>fa4b17068e8dda18d1d436065f9ec1a2</Hash>
</Codenesium>*/