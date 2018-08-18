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
    <Hash>2727bc0e1a84e200340afa50a9d484f0</Hash>
</Codenesium>*/