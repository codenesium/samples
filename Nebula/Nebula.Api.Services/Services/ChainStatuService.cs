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
	public partial class ChainStatuService : AbstractChainStatuService, IChainStatuService
	{
		public ChainStatuService(
			ILogger<IChainStatuRepository> logger,
			IChainStatuRepository chainStatuRepository,
			IApiChainStatuRequestModelValidator chainStatuModelValidator,
			IBOLChainStatuMapper bolchainStatuMapper,
			IDALChainStatuMapper dalchainStatuMapper,
			IBOLChainMapper bolChainMapper,
			IDALChainMapper dalChainMapper
			)
			: base(logger,
			       chainStatuRepository,
			       chainStatuModelValidator,
			       bolchainStatuMapper,
			       dalchainStatuMapper,
			       bolChainMapper,
			       dalChainMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>588844ce0dc623ca3f6a51702c21e694</Hash>
</Codenesium>*/