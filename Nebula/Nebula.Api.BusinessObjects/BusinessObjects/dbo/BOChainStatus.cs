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
			IApiChainStatusRequestModelValidator chainStatusModelValidator,
			IBOLChainStatusMapper chainStatusMapper)
			: base(logger, chainStatusRepository, chainStatusModelValidator, chainStatusMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>4259b7c37cd0a119c2d0a931c3a31619</Hash>
</Codenesium>*/