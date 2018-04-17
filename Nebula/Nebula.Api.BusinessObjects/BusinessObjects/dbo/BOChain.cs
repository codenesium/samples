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
			IChainModelValidator chainModelValidator)
			: base(logger, chainRepository, chainModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>b2fe76976f945f50d4b905e447dd2ec8</Hash>
</Codenesium>*/