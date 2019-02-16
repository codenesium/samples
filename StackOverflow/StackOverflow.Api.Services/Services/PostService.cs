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
			IDALPostMapper dalPostMapper)
			: base(logger,
			       mediator,
			       postRepository,
			       postModelValidator,
			       dalPostMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5306230a868b8b0e0d87df2d22a01638</Hash>
</Codenesium>*/