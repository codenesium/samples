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
    <Hash>a78191b695a29a518d4d15e8e989f5fa</Hash>
</Codenesium>*/