using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class PostTypesService : AbstractPostTypesService, IPostTypesService
	{
		public PostTypesService(
			ILogger<IPostTypesRepository> logger,
			IMediator mediator,
			IPostTypesRepository postTypesRepository,
			IApiPostTypesServerRequestModelValidator postTypesModelValidator,
			IDALPostTypesMapper dalPostTypesMapper,
			IDALPostsMapper dalPostsMapper)
			: base(logger,
			       mediator,
			       postTypesRepository,
			       postTypesModelValidator,
			       dalPostTypesMapper,
			       dalPostsMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9a40a66be25ec7a8fadcde8cf42b8a8a</Hash>
</Codenesium>*/