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
			IApiSpaceModelValidator spaceModelValidator)
			: base(logger, spaceRepository, spaceModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>f4cb44024b4945fd9e7a2cd67dc80cfa</Hash>
</Codenesium>*/