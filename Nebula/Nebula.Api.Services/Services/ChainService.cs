using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public class ChainService: AbstractChainService, IChainService
	{
		public ChainService(
			ILogger<ChainRepository> logger,
			IChainRepository chainRepository,
			IApiChainRequestModelValidator chainModelValidator,
			IBOLChainMapper BOLchainMapper,
			IDALChainMapper DALchainMapper)
			: base(logger, chainRepository,
			       chainModelValidator,
			       BOLchainMapper,
			       DALchainMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>debf5319ffb5293dbed3966af65e095f</Hash>
</Codenesium>*/