using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public class SpaceRepository: AbstractSpaceRepository, ISpaceRepository
	{
		public SpaceRepository(
			IObjectMapper mapper,
			ILogger<SpaceRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>66ae6623498ff82c53abce0bbf06b1c8</Hash>
</Codenesium>*/