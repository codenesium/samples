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
			IApiSpaceXSpaceFeatureRequestModelValidator spaceXSpaceFeatureModelValidator,
			IBOLSpaceXSpaceFeatureMapper spaceXSpaceFeatureMapper)
			: base(logger, spaceXSpaceFeatureRepository, spaceXSpaceFeatureModelValidator, spaceXSpaceFeatureMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>093ace81327f6e2ffdbe54b4edfb8445</Hash>
</Codenesium>*/