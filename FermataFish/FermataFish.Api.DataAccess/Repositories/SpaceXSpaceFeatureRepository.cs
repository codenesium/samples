using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public partial class SpaceXSpaceFeatureRepository : AbstractSpaceXSpaceFeatureRepository, ISpaceXSpaceFeatureRepository
	{
		public SpaceXSpaceFeatureRepository(
			ILogger<SpaceXSpaceFeatureRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>90ec8b63e357e4b42082d4083cebb7bd</Hash>
</Codenesium>*/