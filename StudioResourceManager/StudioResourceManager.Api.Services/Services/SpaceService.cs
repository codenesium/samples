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
	public partial class SpaceService : AbstractSpaceService, ISpaceService
	{
		public SpaceService(
			ILogger<ISpaceRepository> logger,
			ISpaceRepository spaceRepository,
			IApiSpaceRequestModelValidator spaceModelValidator,
			IBOLSpaceMapper bolspaceMapper,
			IDALSpaceMapper dalspaceMapper,
			IBOLSpaceSpaceFeatureMapper bolSpaceSpaceFeatureMapper,
			IDALSpaceSpaceFeatureMapper dalSpaceSpaceFeatureMapper)
			: base(logger,
			       spaceRepository,
			       spaceModelValidator,
			       bolspaceMapper,
			       dalspaceMapper,
			       bolSpaceSpaceFeatureMapper,
			       dalSpaceSpaceFeatureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8d594ff0c7669fa450fded0586fccc32</Hash>
</Codenesium>*/