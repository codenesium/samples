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
			IDALPostHistoryMapper dalPostHistoryMapper)
			: base(logger,
			       mediator,
			       postHistoryRepository,
			       postHistoryModelValidator,
			       dalPostHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5ca007e5e328f6151ae93ee2bec1e0c6</Hash>
</Codenesium>*/