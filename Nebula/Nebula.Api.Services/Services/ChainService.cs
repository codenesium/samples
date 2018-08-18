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
			IBOLClaspMapper bolClaspMapper,
			IDALClaspMapper dalClaspMapper,
			IBOLLinkMapper bolLinkMapper,
			IDALLinkMapper dalLinkMapper
			)
			: base(logger,
			       chainRepository,
			       chainModelValidator,
			       bolchainMapper,
			       dalchainMapper,
			       bolClaspMapper,
			       dalClaspMapper,
			       bolLinkMapper,
			       dalLinkMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d32c9d35e45b8ebed713769c129a2ee8</Hash>
</Codenesium>*/