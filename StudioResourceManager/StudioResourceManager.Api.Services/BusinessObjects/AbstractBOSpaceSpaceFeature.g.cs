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
    <Hash>43db163e8bf9786a14024d0956c7dff7</Hash>
</Codenesium>*/