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
	public class SpaceFeatureService: AbstractSpaceFeatureService, ISpaceFeatureService
	{
		public SpaceFeatureService(
			ILogger<SpaceFeatureRepository> logger,
			ISpaceFeatureRepository spaceFeatureRepository,
			IApiSpaceFeatureRequestModelValidator spaceFeatureModelValidator,
			IBOLSpaceFeatureMapper BOLspaceFeatureMapper,
			IDALSpaceFeatureMapper DALspaceFeatureMapper)
			: base(logger, spaceFeatureRepository,
			       spaceFeatureModelValidator,
			       BOLspaceFeatureMapper,
			       DALspaceFeatureMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>64643e9c107eccabf021c955c8821bea</Hash>
</Codenesium>*/