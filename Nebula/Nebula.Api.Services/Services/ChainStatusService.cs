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
	public partial class ChainStatusService : AbstractChainStatusService, IChainStatusService
	{
		public ChainStatusService(
			ILogger<IChainStatusRepository> logger,
			IChainStatusRepository chainStatusRepository,
			IApiChainStatusRequestModelValidator chainStatusModelValidator,
			IBOLChainStatusMapper bolchainStatusMapper,
			IDALChainStatusMapper dalchainStatusMapper,
			IBOLChainMapper bolChainMapper,
			IDALChainMapper dalChainMapper)
			: base(logger,
			       chainStatusRepository,
			       chainStatusModelValidator,
			       bolchainStatusMapper,
			       dalchainStatusMapper,
			       bolChainMapper,
			       dalChainMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>29b635a76c6f34528cfdcbcc83977148</Hash>
</Codenesium>*/