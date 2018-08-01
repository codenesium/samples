using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
	public partial class ChainRepository : AbstractChainRepository, IChainRepository
	{
		public ChainRepository(
			ILogger<ChainRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>19585b722a2aaa46ad8992f03f1ae13b</Hash>
</Codenesium>*/