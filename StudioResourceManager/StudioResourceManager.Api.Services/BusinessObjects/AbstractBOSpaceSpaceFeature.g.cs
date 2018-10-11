using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractBOSpaceSpaceFeature : AbstractBusinessObject
	{
		public AbstractBOSpaceSpaceFeature()
			: base()
		{
		}

		public virtual void SetProperties(int spaceId,
		                                  int spaceFeatureId)
		{
			this.SpaceFeatureId = spaceFeatureId;
			this.SpaceId = spaceId;
		}

		public int SpaceFeatureId { get; private set; }

		public int SpaceId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5e814b93c4181d27fe0bb0a73af21817</Hash>
</Codenesium>*/