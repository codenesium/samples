using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class PostLinkService : AbstractPostLinkService, IPostLinkService
	{
		public PostLinkService(
			ILogger<IPostLinkRepository> logger,
			IMediator mediator,
			IPostLinkRepository postLinkRepository,
			IApiPostLinkServerRequestModelValidator postLinkModelValidator,
			IBOLPostLinkMapper bolPostLinkMapper,
			IDALPostLinkMapper dalPostLinkMapper)
			: base(logger,
			       mediator,
			       postLinkRepository,
			       postLinkModelValidator,
			       bolPostLinkMapper,
			       dalPostLinkMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>057ce5dd0d9dbbbf95ee42ff0fa5a194</Hash>
</Codenesium>*/