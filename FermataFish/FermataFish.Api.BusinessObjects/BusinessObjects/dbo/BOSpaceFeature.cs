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
			ISpaceFeatureModelValidator spaceFeatureModelValidator)
			: base(logger, spaceFeatureRepository, spaceFeatureModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>c9149ae92bb15f5b13a9c98eb98203da</Hash>
</Codenesium>*/