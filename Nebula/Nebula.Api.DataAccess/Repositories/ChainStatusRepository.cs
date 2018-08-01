using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
	public partial class ChainStatusRepository : AbstractChainStatusRepository, IChainStatusRepository
	{
		public ChainStatusRepository(
			ILogger<ChainStatusRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2217b4b804afebda89506bab84890f62</Hash>
</Codenesium>*/