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
			IApiChainStatusModelValidator chainStatusModelValidator)
			: base(logger, chainStatusRepository, chainStatusModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>3543d33dba12274a17057f95909f1b14</Hash>
</Codenesium>*/