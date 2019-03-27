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
	public partial class SpaceSpaceFeatureRepository : AbstractSpaceSpaceFeatureRepository, ISpaceSpaceFeatureRepository
	{
		public SpaceSpaceFeatureRepository(
			ILogger<SpaceSpaceFeatureRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>34d89a591024c76e26ff000999443bbe</Hash>
</Codenesium>*/