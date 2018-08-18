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
	public partial class SpaceFeatureService : AbstractSpaceFeatureService, ISpaceFeatureService
	{
		public SpaceFeatureService(
			ILogger<ISpaceFeatureRepository> logger,
			ISpaceFeatureRepository spaceFeatureRepository,
			IApiSpaceFeatureRequestModelValidator spaceFeatureModelValidator,
			IBOLSpaceFeatureMapper bolspaceFeatureMapper,
			IDALSpaceFeatureMapper dalspaceFeatureMapper,
			IBOLSpaceXSpaceFeatureMapper bolSpaceXSpaceFeatureMapper,
			IDALSpaceXSpaceFeatureMapper dalSpaceXSpaceFeatureMapper
			)
			: base(logger,
			       spaceFeatureRepository,
			       spaceFeatureModelValidator,
			       bolspaceFeatureMapper,
			       dalspaceFeatureMapper,
			       bolSpaceXSpaceFeatureMapper,
			       dalSpaceXSpaceFeatureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>046a471d0832bb972fee04ac9d5a2bba</Hash>
</Codenesium>*/