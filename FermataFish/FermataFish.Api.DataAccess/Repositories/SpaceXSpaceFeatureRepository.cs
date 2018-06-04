using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public class SpaceXSpaceFeatureRepository: AbstractSpaceXSpaceFeatureRepository, ISpaceXSpaceFeatureRepository
	{
		public SpaceXSpaceFeatureRepository(
			ILogger<SpaceXSpaceFeatureRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>da004b8000c54dd2208093b7a694ec1d</Hash>
</Codenesium>*/