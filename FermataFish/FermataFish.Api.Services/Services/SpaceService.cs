using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public class SpaceService: AbstractSpaceService, ISpaceService
	{
		public SpaceService(
			ILogger<SpaceRepository> logger,
			ISpaceRepository spaceRepository,
			IApiSpaceRequestModelValidator spaceModelValidator,
			IBOLSpaceMapper BOLspaceMapper,
			IDALSpaceMapper DALspaceMapper)
			: base(logger, spaceRepository,
			       spaceModelValidator,
			       BOLspaceMapper,
			       DALspaceMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>edfc616fd919de6bd7897fe50a293497</Hash>
</Codenesium>*/