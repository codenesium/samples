using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IDALSpaceXSpaceFeatureMapper
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
    <Hash>6040557533e17c83a82ee4500d7104f7</Hash>
</Codenesium>*/