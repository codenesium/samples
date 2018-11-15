using Microsoft.EntityFrameworkCore;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IDALSpaceFeatureMapper
	{
		SpaceFeature MapBOToEF(
			BOSpaceFeature bo);

		BOSpaceFeature MapEFToBO(
			SpaceFeature efSpaceFeature);

		List<BOSpaceFeature> MapEFToBO(
			List<SpaceFeature> records);
	}
}

/*<Codenesium>
    <Hash>cff56c8a48ff72d1ad0893c2b1cab1b2</Hash>
</Codenesium>*/