using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public partial class SpaceRepository : AbstractSpaceRepository, ISpaceRepository
	{
		public SpaceRepository(
			ILogger<SpaceRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1d95c7026138d1930a10b6ea5c7e7f01</Hash>
</Codenesium>*/