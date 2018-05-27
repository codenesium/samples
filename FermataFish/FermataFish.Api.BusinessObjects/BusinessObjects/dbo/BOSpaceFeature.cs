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
			IApiSpaceFeatureRequestModelValidator spaceFeatureModelValidator,
			IBOLSpaceFeatureMapper spaceFeatureMapper)
			: base(logger, spaceFeatureRepository, spaceFeatureModelValidator, spaceFeatureMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>6507a9cab2dea1d3398d97e9250551df</Hash>
</Codenesium>*/