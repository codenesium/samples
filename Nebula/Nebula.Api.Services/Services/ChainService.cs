using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial class ChainService : AbstractChainService, IChainService
	{
		public ChainService(
			ILogger<IChainRepository> logger,
			IChainRepository chainRepository,
			IApiChainRequestModelValidator chainModelValidator,
			IBOLChainMapper bolchainMapper,
			IDALChainMapper dalchainMapper,
			IBOLLinkMapper bolLinkMapper,
			IDALLinkMapper dalLinkMapper)
			: base(logger,
			       chainRepository,
			       chainModelValidator,
			       bolchainMapper,
			       dalchainMapper,
			       bolLinkMapper,
			       dalLinkMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6e95b1df6886dc401e9a6a21e678599f</Hash>
</Codenesium>*/