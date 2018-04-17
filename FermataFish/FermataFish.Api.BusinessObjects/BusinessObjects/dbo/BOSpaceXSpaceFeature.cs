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
			ISpaceXSpaceFeatureModelValidator spaceXSpaceFeatureModelValidator)
			: base(logger, spaceXSpaceFeatureRepository, spaceXSpaceFeatureModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>64d353c97d5497915399c07b19b9ef84</Hash>
</Codenesium>*/