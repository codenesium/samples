using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public class SpaceRepository: AbstractSpaceRepository, ISpaceRepository
	{
		public SpaceRepository(
			ILogger<SpaceRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>2efca689e870e70b11995bb5bd69fbbf</Hash>
</Codenesium>*/