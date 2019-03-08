using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class PostsService : AbstractPostsService, IPostsService
	{
		public PostsService(
			ILogger<IPostsRepository> logger,
			IMediator mediator,
			IPostsRepository postsRepository,
			IApiPostsServerRequestModelValidator postsModelValidator,
			IDALPostsMapper dalPostsMapper,
			IDALCommentsMapper dalCommentsMapper,
			IDALTagsMapper dalTagsMapper,
			IDALVotesMapper dalVotesMapper,
			IDALPostHistoryMapper dalPostHistoryMapper,
			IDALPostLinksMapper dalPostLinksMapper)
			: base(logger,
			       mediator,
			       postsRepository,
			       postsModelValidator,
			       dalPostsMapper,
			       dalCommentsMapper,
			       dalTagsMapper,
			       dalVotesMapper,
			       dalPostHistoryMapper,
			       dalPostLinksMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2c5e60d5112f193b0b7dac0d427e91f6</Hash>
</Codenesium>*/