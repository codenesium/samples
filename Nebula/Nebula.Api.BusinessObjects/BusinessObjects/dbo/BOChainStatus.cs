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
	public class BOChainStatus: AbstractBOChainStatus, IBOChainStatus
	{
		public BOChainStatus(
			ILogger<ChainStatusRepository> logger,
			IChainStatusRepository chainStatusRepository,
			IChainStatusModelValidator chainStatusModelValidator)
			: base(logger, chainStatusRepository, chainStatusModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>1a1bc06bd2e8f1f77bd7c14e7e5a181c</Hash>
</Codenesium>*/