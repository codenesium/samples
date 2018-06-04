using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class BOSpaceXSpaceFeature: AbstractBusinessObject
	{
		public BOSpaceXSpaceFeature() : base()
		{}

		public void SetProperties(int id,
		                          int spaceFeatureId,
		                          int spaceId)
		{
			this.Id = id.ToInt();
			this.SpaceFeatureId = spaceFeatureId.ToInt();
			this.SpaceId = spaceId.ToInt();
		}

		public int Id { get; private set; }
		public int SpaceFeatureId { get; private set; }
		public int SpaceId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e46bad090d560f9da20262ce1fe5cff7</Hash>
</Codenesium>*/