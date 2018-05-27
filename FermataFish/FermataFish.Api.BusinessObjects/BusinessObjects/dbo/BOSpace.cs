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
			IApiSpaceRequestModelValidator spaceModelValidator,
			IBOLSpaceMapper spaceMapper)
			: base(logger, spaceRepository, spaceModelValidator, spaceMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>008c3fdc1191c2b03e5b25fe3245b71f</Hash>
</Codenesium>*/