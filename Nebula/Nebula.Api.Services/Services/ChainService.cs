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
			IBOLChainMapper bolChainMapper,
			IDALChainMapper dalChainMapper,
			IBOLClaspMapper bolClaspMapper,
			IDALClaspMapper dalClaspMapper,
			IBOLLinkMapper bolLinkMapper,
			IDALLinkMapper dalLinkMapper)
			: base(logger,
			       mediator,
			       chainRepository,
			       chainModelValidator,
			       bolChainMapper,
			       dalChainMapper,
			       bolClaspMapper,
			       dalClaspMapper,
			       bolLinkMapper,
			       dalLinkMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d0b9272fee9b7ab127c0d27e912c1823</Hash>
</Codenesium>*/