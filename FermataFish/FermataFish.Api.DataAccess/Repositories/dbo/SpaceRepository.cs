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
			IDALSpaceMapper mapper,
			ILogger<SpaceRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>ed33a7039d93c160754b50cce05cc605</Hash>
</Codenesium>*/