using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractBOSpaceXSpaceFeature : AbstractBusinessObject
        {
                public AbstractBOSpaceXSpaceFeature()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
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
    <Hash>5e3e623bb1a1e7991da4962e8974aed5</Hash>
</Codenesium>*/