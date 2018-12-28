using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class PostHistoryService : AbstractPostHistoryService, IPostHistoryService
	{
		public PostHistoryService(
			ILogger<IPostHistoryRepository> logger,
			IMediator mediator,
			IPostHistoryRepository postHistoryRepository,
			IApiPostHistoryServerRequestModelValidator postHistoryModelValidator,
			IBOLPostHistoryMapper bolPostHistoryMapper,
			IDALPostHistoryMapper dalPostHistoryMapper)
			: base(logger,
			       mediator,
			       postHistoryRepository,
			       postHistoryModelValidator,
			       bolPostHistoryMapper,
			       dalPostHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4663e6c078e403f370c72c6f9718f253</Hash>
</Codenesium>*/