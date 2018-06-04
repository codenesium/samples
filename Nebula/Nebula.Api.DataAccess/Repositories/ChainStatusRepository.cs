using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
	public class ChainStatusRepository: AbstractChainStatusRepository, IChainStatusRepository
	{
		public ChainStatusRepository(
			ILogger<ChainStatusRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>fb73644c12a8d198cf0097619d319e23</Hash>
</Codenesium>*/