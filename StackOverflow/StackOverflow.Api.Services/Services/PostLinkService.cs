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
			IDALPostLinkMapper dalPostLinkMapper)
			: base(logger,
			       mediator,
			       postLinkRepository,
			       postLinkModelValidator,
			       dalPostLinkMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d8240de821d497587c17ac030056e1fa</Hash>
</Codenesium>*/