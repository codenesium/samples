using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractBOSpaceXSpaceFeature: AbstractBusinessObject
        {
                public AbstractBOSpaceXSpaceFeature() : base()
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
    <Hash>8fb3f586f50fdd6388f5b22cb10d8084</Hash>
</Codenesium>*/