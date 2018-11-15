using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial class SpaceFeatureRepository : AbstractSpaceFeatureRepository, ISpaceFeatureRepository
	{
		public SpaceFeatureRepository(
			ILogger<SpaceFeatureRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>963752272583860dccea934798a430e7</Hash>
</Codenesium>*/