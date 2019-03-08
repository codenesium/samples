using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class PostLinksService : AbstractPostLinksService, IPostLinksService
	{
		public PostLinksService(
			ILogger<IPostLinksRepository> logger,
			IMediator mediator,
			IPostLinksRepository postLinksRepository,
			IApiPostLinksServerRequestModelValidator postLinksModelValidator,
			IDALPostLinksMapper dalPostLinksMapper)
			: base(logger,
			       mediator,
			       postLinksRepository,
			       postLinksModelValidator,
			       dalPostLinksMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b7b05080e04c0e892704730d554dae04</Hash>
</Codenesium>*/