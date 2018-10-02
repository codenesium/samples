using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALSpaceSpaceFeatureMapper
	{
		SpaceSpaceFeature MapBOToEF(
			BOSpaceSpaceFeature bo);

		BOSpaceSpaceFeature MapEFToBO(
			SpaceSpaceFeature efSpaceSpaceFeature);

		List<BOSpaceSpaceFeature> MapEFToBO(
			List<SpaceSpaceFeature> records);
	}
}

/*<Codenesium>
    <Hash>2281717f9fc10993242fc8c19efc341a</Hash>
</Codenesium>*/