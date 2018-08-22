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
		                                  int spaceId,
		                                  int studioId)
		{
			this.Id = id;
			this.SpaceFeatureId = spaceFeatureId;
			this.SpaceId = spaceId;
			this.StudioId = studioId;
		}

		public int Id { get; private set; }

		public int SpaceFeatureId { get; private set; }

		public int SpaceId { get; private set; }

		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>53efeeacf76407042ad1c1c282b60e1e</Hash>
</Codenesium>*/