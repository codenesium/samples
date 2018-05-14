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
	public class BOSpaceFeature: AbstractBOSpaceFeature, IBOSpaceFeature
	{
		public BOSpaceFeature(
			ILogger<SpaceFeatureRepository> logger,
			ISpaceFeatureRepository spaceFeatureRepository,
			IApiSpaceFeatureModelValidator spaceFeatureModelValidator)
			: base(logger, spaceFeatureRepository, spaceFeatureModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>e2dcfefc8cc1c73a6b17766fc24594e6</Hash>
</Codenesium>*/