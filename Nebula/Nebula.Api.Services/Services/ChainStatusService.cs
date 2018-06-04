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
	public class ChainStatusService: AbstractChainStatusService, IChainStatusService
	{
		public ChainStatusService(
			ILogger<ChainStatusRepository> logger,
			IChainStatusRepository chainStatusRepository,
			IApiChainStatusRequestModelValidator chainStatusModelValidator,
			IBOLChainStatusMapper BOLchainStatusMapper,
			IDALChainStatusMapper DALchainStatusMapper)
			: base(logger, chainStatusRepository,
			       chainStatusModelValidator,
			       BOLchainStatusMapper,
			       DALchainStatusMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>3289227d416ce6ad728ea3afb2ee5068</Hash>
</Codenesium>*/