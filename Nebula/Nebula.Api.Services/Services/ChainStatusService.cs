using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class ChainStatusService : AbstractChainStatusService, IChainStatusService
	{
		public ChainStatusService(
			ILogger<IChainStatusRepository> logger,
			IChainStatusRepository chainStatusRepository,
			IApiChainStatusServerRequestModelValidator chainStatusModelValidator,
			IBOLChainStatusMapper bolChainStatusMapper,
			IDALChainStatusMapper dalChainStatusMapper,
			IBOLChainMapper bolChainMapper,
			IDALChainMapper dalChainMapper)
			: base(logger,
			       chainStatusRepository,
			       chainStatusModelValidator,
			       bolChainStatusMapper,
			       dalChainStatusMapper,
			       bolChainMapper,
			       dalChainMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>933fd1919f7e01f5a1d1e365d7d1335d</Hash>
</Codenesium>*/