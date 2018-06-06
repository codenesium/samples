using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
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
    <Hash>2925098134ea52df03c1eaa7f60fa9dd</Hash>
</Codenesium>*/