using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class PostService : AbstractPostService, IPostService
	{
		public PostService(
			ILogger<IPostRepository> logger,
			IPostRepository postRepository,
			IApiPostServerRequestModelValidator postModelValidator,
			IBOLPostMapper bolPostMapper,
			IDALPostMapper dalPostMapper)
			: base(logger,
			       postRepository,
			       postModelValidator,
			       bolPostMapper,
			       dalPostMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>91c55567050c3a49f63e6d432cdfb9d0</Hash>
</Codenesium>*/