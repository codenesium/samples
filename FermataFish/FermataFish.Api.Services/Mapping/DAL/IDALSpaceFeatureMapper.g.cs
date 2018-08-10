using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
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
    <Hash>26e210ff1570a3e421aac60b3749bf67</Hash>
</Codenesium>*/