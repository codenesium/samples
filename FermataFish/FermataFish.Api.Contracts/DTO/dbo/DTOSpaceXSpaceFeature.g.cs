using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class DTOSpaceXSpaceFeature: AbstractDTO
	{
		public DTOSpaceXSpaceFeature() : base()
		{}

		public void SetProperties(int id,
		                          int spaceFeatureId,
		                          int spaceId)
		{
			this.Id = id.ToInt();
			this.SpaceFeatureId = spaceFeatureId.ToInt();
			this.SpaceId = spaceId.ToInt();
		}

		public int Id { get; set; }
		public int SpaceFeatureId { get; set; }
		public int SpaceId { get; set; }
	}
}

/*<Codenesium>
    <Hash>e413d064e4d9d800f26df3c6892a37a4</Hash>
</Codenesium>*/