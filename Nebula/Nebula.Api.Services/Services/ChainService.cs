using MediatR;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class ChainService : AbstractChainService, IChainService
	{
		public ChainService(
			ILogger<IChainRepository> logger,
			IMediator mediator,
			IChainRepository chainRepository,
			IApiChainServerRequestModelValidator chainModelValidator,
			IDALChainMapper dalChainMapper,
			IDALClaspMapper dalClaspMapper,
			IDALLinkMapper dalLinkMapper)
			: base(logger,
			       mediator,
			       chainRepository,
			       chainModelValidator,
			       dalChainMapper,
			       dalClaspMapper,
			       dalLinkMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>91111e5e38e4c89b678a21c5cc5599df</Hash>
</Codenesium>*/