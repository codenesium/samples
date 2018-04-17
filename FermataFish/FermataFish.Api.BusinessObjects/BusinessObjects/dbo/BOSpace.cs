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
	public class BOSpace: AbstractBOSpace, IBOSpace
	{
		public BOSpace(
			ILogger<SpaceRepository> logger,
			ISpaceRepository spaceRepository,
			ISpaceModelValidator spaceModelValidator)
			: base(logger, spaceRepository, spaceModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>8e78f95764a762a7fb16ff368b2b57a2</Hash>
</Codenesium>*/