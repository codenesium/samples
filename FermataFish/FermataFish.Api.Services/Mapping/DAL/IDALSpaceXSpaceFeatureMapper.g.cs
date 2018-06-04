using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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
    <Hash>a3ae949c419fd51a9a1bdf969c3edee5</Hash>
</Codenesium>*/