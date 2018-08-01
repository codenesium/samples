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
    <Hash>519a32d40d25a1c9c239b7340194470f</Hash>
</Codenesium>*/