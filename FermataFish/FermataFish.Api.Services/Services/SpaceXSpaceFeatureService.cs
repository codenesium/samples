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
	public class SpaceXSpaceFeatureService: AbstractSpaceXSpaceFeatureService, ISpaceXSpaceFeatureService
	{
		public SpaceXSpaceFeatureService(
			ILogger<SpaceXSpaceFeatureRepository> logger,
			ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository,
			IApiSpaceXSpaceFeatureRequestModelValidator spaceXSpaceFeatureModelValidator,
			IBOLSpaceXSpaceFeatureMapper BOLspaceXSpaceFeatureMapper,
			IDALSpaceXSpaceFeatureMapper DALspaceXSpaceFeatureMapper)
			: base(logger, spaceXSpaceFeatureRepository,
			       spaceXSpaceFeatureModelValidator,
			       BOLspaceXSpaceFeatureMapper,
			       DALspaceXSpaceFeatureMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>6dc664dbd130860db398d2ef244cb86c</Hash>
</Codenesium>*/