using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
	public class ChainRepository: AbstractChainRepository, IChainRepository
	{
		public ChainRepository(
			ILogger<ChainRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>c6772384218b7852cda183feaa48e326</Hash>
</Codenesium>*/