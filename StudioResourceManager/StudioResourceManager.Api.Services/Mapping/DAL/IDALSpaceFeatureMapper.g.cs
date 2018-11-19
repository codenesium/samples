using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>001f311095ec1e5e374419757cb9da2c</Hash>
</Codenesium>*/