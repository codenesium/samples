using MediatR;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class ChainStatusService : AbstractChainStatusService, IChainStatusService
	{
		public ChainStatusService(
			ILogger<IChainStatusRepository> logger,
			IMediator mediator,
			IChainStatusRepository chainStatusRepository,
			IApiChainStatusServerRequestModelValidator chainStatusModelValidator,
			IDALChainStatusMapper dalChainStatusMapper,
			IDALChainMapper dalChainMapper)
			: base(logger,
			       mediator,
			       chainStatusRepository,
			       chainStatusModelValidator,
			       dalChainStatusMapper,
			       dalChainMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e2dc9581cbf132d275a2f37ef9acd2fc</Hash>
</Codenesium>*/