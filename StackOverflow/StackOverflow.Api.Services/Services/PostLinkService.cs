using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class PostLinkService : AbstractPostLinkService, IPostLinkService
	{
		public PostLinkService(
			ILogger<IPostLinkRepository> logger,
			IPostLinkRepository postLinkRepository,
			IApiPostLinkServerRequestModelValidator postLinkModelValidator,
			IBOLPostLinkMapper bolPostLinkMapper,
			IDALPostLinkMapper dalPostLinkMapper)
			: base(logger,
			       postLinkRepository,
			       postLinkModelValidator,
			       bolPostLinkMapper,
			       dalPostLinkMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9c3aaaadc99ac3446689fcc4971e5f5a</Hash>
</Codenesium>*/