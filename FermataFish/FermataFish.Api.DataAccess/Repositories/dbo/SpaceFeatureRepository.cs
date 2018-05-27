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
	public class SpaceFeatureRepository: AbstractSpaceFeatureRepository, ISpaceFeatureRepository
	{
		public SpaceFeatureRepository(
			IDALSpaceFeatureMapper mapper,
			ILogger<SpaceFeatureRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>c32fd013faa7bfefe4c2d3d248c39570</Hash>
</Codenesium>*/