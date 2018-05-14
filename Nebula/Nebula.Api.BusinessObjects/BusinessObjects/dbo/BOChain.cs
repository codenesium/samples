using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class BOChain: AbstractBOChain, IBOChain
	{
		public BOChain(
			ILogger<ChainRepository> logger,
			IChainRepository chainRepository,
			IApiChainModelValidator chainModelValidator)
			: base(logger, chainRepository, chainModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>aad33187cbb62b93b8316722b6eda190</Hash>
</Codenesium>*/