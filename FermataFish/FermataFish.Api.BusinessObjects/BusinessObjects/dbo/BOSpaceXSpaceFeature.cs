using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class BOSpaceXSpaceFeature: AbstractBOSpaceXSpaceFeature, IBOSpaceXSpaceFeature
	{
		public BOSpaceXSpaceFeature(
			ILogger<SpaceXSpaceFeatureRepository> logger,
			ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository,
			IApiSpaceXSpaceFeatureModelValidator spaceXSpaceFeatureModelValidator)
			: base(logger, spaceXSpaceFeatureRepository, spaceXSpaceFeatureModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>a1e0e5cdc8409d6b1c49dba0665f19d7</Hash>
</Codenesium>*/