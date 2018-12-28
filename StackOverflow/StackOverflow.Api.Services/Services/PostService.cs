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
			IBOLPostMapper bolPostMapper,
			IDALPostMapper dalPostMapper)
			: base(logger,
			       mediator,
			       postRepository,
			       postModelValidator,
			       bolPostMapper,
			       dalPostMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7eb728aaeb3b1d90813c616c87088c91</Hash>
</Codenesium>*/