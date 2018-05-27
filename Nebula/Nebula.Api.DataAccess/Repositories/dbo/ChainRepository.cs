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
	public class ChainRepository: AbstractChainRepository, IChainRepository
	{
		public ChainRepository(
			IDALChainMapper mapper,
			ILogger<ChainRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>dbc048fb3beabd9084f613a20625c381</Hash>
</Codenesium>*/