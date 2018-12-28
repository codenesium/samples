using MediatR;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class LinkService : AbstractLinkService, ILinkService
	{
		public LinkService(
			ILogger<ILinkRepository> logger,
			IMediator mediator,
			ILinkRepository linkRepository,
			IApiLinkServerRequestModelValidator linkModelValidator,
			IBOLLinkMapper bolLinkMapper,
			IDALLinkMapper dalLinkMapper,
			IBOLLinkLogMapper bolLinkLogMapper,
			IDALLinkLogMapper dalLinkLogMapper)
			: base(logger,
			       mediator,
			       linkRepository,
			       linkModelValidator,
			       bolLinkMapper,
			       dalLinkMapper,
			       bolLinkLogMapper,
			       dalLinkLogMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9d3805c9d131562161b47c5f7120ff5e</Hash>
</Codenesium>*/