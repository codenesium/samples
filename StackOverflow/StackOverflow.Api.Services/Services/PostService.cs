using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class PostService : AbstractPostService, IPostService
	{
		public PostService(
			ILogger<IPostRepository> logger,
			IMediator mediator,
			IPostRepository postRepository,
			IApiPostServerRequestModelValidator postModelValidator,
			IDALPostMapper dalPostMapper,
			IDALCommentMapper dalCommentMapper,
			IDALTagMapper dalTagMapper,
			IDALVoteMapper dalVoteMapper,
			IDALPostHistoryMapper dalPostHistoryMapper,
			IDALPostLinkMapper dalPostLinkMapper)
			: base(logger,
			       mediator,
			       postRepository,
			       postModelValidator,
			       dalPostMapper,
			       dalCommentMapper,
			       dalTagMapper,
			       dalVoteMapper,
			       dalPostHistoryMapper,
			       dalPostLinkMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8c713536fbb4a3e22558f1835beacbde</Hash>
</Codenesium>*/