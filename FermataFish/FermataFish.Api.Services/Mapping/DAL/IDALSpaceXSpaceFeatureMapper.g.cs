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
    <Hash>97b10433b93d06b9647d90af862aef36</Hash>
</Codenesium>*/