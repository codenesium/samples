using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IDALSpaceXSpaceFeatureMapper
	{
		SpaceXSpaceFeature MapBOToEF(
			BOSpaceXSpaceFeature bo);

		BOSpaceXSpaceFeature MapEFToBO(
			SpaceXSpaceFeature efSpaceXSpaceFeature);

		List<BOSpaceXSpaceFeature> MapEFToBO(
			List<SpaceXSpaceFeature> records);
	}
}

/*<Codenesium>
    <Hash>a449fc6eb5d27fb35ba6ef2400c12f69</Hash>
</Codenesium>*/