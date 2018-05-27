using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public class SpaceXSpaceFeatureRepository: AbstractSpaceXSpaceFeatureRepository, ISpaceXSpaceFeatureRepository
	{
		public SpaceXSpaceFeatureRepository(
			IDALSpaceXSpaceFeatureMapper mapper,
			ILogger<SpaceXSpaceFeatureRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>1fb9494e000838722c84ff2e90348287</Hash>
</Codenesium>*/