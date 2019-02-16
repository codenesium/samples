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
			IDALLinkMapper dalLinkMapper,
			IDALLinkLogMapper dalLinkLogMapper)
			: base(logger,
			       mediator,
			       linkRepository,
			       linkModelValidator,
			       dalLinkMapper,
			       dalLinkLogMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c05e5d6b6d92bdd9f5041d970360b1bf</Hash>
</Codenesium>*/