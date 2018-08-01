using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Services
{
	public partial class SpaceXSpaceFeatureService : AbstractSpaceXSpaceFeatureService, ISpaceXSpaceFeatureService
	{
		public SpaceXSpaceFeatureService(
			ILogger<ISpaceXSpaceFeatureRepository> logger,
			ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository,
			IApiSpaceXSpaceFeatureRequestModelValidator spaceXSpaceFeatureModelValidator,
			IBOLSpaceXSpaceFeatureMapper bolspaceXSpaceFeatureMapper,
			IDALSpaceXSpaceFeatureMapper dalspaceXSpaceFeatureMapper
			)
			: base(logger,
			       spaceXSpaceFeatureRepository,
			       spaceXSpaceFeatureModelValidator,
			       bolspaceXSpaceFeatureMapper,
			       dalspaceXSpaceFeatureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>73ab8c50470169342e63b7aa1e0b4190</Hash>
</Codenesium>*/