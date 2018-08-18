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
    <Hash>9a802dc46f30fbc8e831e9bf920437d3</Hash>
</Codenesium>*/