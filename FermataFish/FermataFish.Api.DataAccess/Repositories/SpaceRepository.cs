using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>63e09eb1f6725d2adbc336dae62d5220</Hash>
</Codenesium>*/