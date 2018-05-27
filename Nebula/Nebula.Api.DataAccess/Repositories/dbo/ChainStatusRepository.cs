using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public class ChainStatusRepository: AbstractChainStatusRepository, IChainStatusRepository
	{
		public ChainStatusRepository(
			IDALChainStatusMapper mapper,
			ILogger<ChainStatusRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>549b4a3325932c51f7e34b43484648ae</Hash>
</Codenesium>*/