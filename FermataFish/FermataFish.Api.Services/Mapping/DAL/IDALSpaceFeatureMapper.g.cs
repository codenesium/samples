using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IDALSpaceFeatureMapper
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
    <Hash>516d05a37ba3c912c1ffc703e45f6016</Hash>
</Codenesium>*/