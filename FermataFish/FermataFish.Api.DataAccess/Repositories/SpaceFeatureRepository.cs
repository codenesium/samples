using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public class SpaceFeatureRepository: AbstractSpaceFeatureRepository, ISpaceFeatureRepository
	{
		public SpaceFeatureRepository(
			ILogger<SpaceFeatureRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>04bff05ab245f91dbb436061c7f18467</Hash>
</Codenesium>*/