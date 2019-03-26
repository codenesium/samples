using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
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
    <Hash>d2972302d5702ded46e4f84255e2132a</Hash>
</Codenesium>*/