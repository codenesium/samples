using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial class SpaceService : AbstractSpaceService, ISpaceService
	{
		public SpaceService(
			ILogger<ISpaceRepository> logger,
			ISpaceRepository spaceRepository,
			IApiSpaceRequestModelValidator spaceModelValidator,
			IBOLSpaceMapper bolspaceMapper,
			IDALSpaceMapper dalspaceMapper,
			IBOLSpaceXSpaceFeatureMapper bolSpaceXSpaceFeatureMapper,
			IDALSpaceXSpaceFeatureMapper dalSpaceXSpaceFeatureMapper
			)
			: base(logger,
			       spaceRepository,
			       spaceModelValidator,
			       bolspaceMapper,
			       dalspaceMapper,
			       bolSpaceXSpaceFeatureMapper,
			       dalSpaceXSpaceFeatureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2b97a28d923426c2be8690de9c1cf976</Hash>
</Codenesium>*/