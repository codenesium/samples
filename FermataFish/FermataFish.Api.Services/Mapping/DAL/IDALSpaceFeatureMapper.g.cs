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
    <Hash>6d281992e9acd17c713cded4ee87b914</Hash>
</Codenesium>*/