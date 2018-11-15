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
			IDALChainStatusMapper dalChainStatusMapper)
			: base(logger,
			       chainStatusRepository,
			       chainStatusModelValidator,
			       bolChainStatusMapper,
			       dalChainStatusMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>fefb63b44315721897e9760bcddb6571</Hash>
</Codenesium>*/