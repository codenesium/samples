using Codenesium.DataConversionExtensions;
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
    <Hash>77f8d98bba49a564fb7a40d719af8103</Hash>
</Codenesium>*/