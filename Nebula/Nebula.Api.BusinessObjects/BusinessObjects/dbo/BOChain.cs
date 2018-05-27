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
			IApiChainRequestModelValidator chainModelValidator,
			IBOLChainMapper chainMapper)
			: base(logger, chainRepository, chainModelValidator, chainMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>dd2f3156f8876911298ebc159ca5f265</Hash>
</Codenesium>*/