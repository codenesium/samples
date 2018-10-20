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
		                                  int spaceFeatureId,
		                                  bool isDeleted)
		{
			this.SpaceFeatureId = spaceFeatureId;
			this.SpaceId = spaceId;
			this.IsDeleted = isDeleted;
		}

		public int SpaceFeatureId { get; private set; }

		public int SpaceId { get; private set; }

		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>047e80da2d3a2a848642fefa06970c83</Hash>
</Codenesium>*/