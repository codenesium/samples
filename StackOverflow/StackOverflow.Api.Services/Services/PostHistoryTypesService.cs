using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class PostHistoryTypesService : AbstractPostHistoryTypesService, IPostHistoryTypesService
	{
		public PostHistoryTypesService(
			ILogger<IPostHistoryTypesRepository> logger,
			IMediator mediator,
			IPostHistoryTypesRepository postHistoryTypesRepository,
			IApiPostHistoryTypesServerRequestModelValidator postHistoryTypesModelValidator,
			IDALPostHistoryTypesMapper dalPostHistoryTypesMapper,
			IDALPostHistoryMapper dalPostHistoryMapper)
			: base(logger,
			       mediator,
			       postHistoryTypesRepository,
			       postHistoryTypesModelValidator,
			       dalPostHistoryTypesMapper,
			       dalPostHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7851b7b984702ebc74d8b8673c2a6fee</Hash>
</Codenesium>*/