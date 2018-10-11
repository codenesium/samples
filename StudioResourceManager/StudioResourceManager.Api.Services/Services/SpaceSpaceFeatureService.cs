using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class SpaceSpaceFeatureService : AbstractSpaceSpaceFeatureService, ISpaceSpaceFeatureService
	{
		public SpaceSpaceFeatureService(
			ILogger<ISpaceSpaceFeatureRepository> logger,
			ISpaceSpaceFeatureRepository spaceSpaceFeatureRepository,
			IApiSpaceSpaceFeatureRequestModelValidator spaceSpaceFeatureModelValidator,
			IBOLSpaceSpaceFeatureMapper bolspaceSpaceFeatureMapper,
			IDALSpaceSpaceFeatureMapper dalspaceSpaceFeatureMapper)
			: base(logger,
			       spaceSpaceFeatureRepository,
			       spaceSpaceFeatureModelValidator,
			       bolspaceSpaceFeatureMapper,
			       dalspaceSpaceFeatureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>73ede0f73b2eb9e29676210d4fe8b8b3</Hash>
</Codenesium>*/