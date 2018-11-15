using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class PostHistoryService : AbstractPostHistoryService, IPostHistoryService
	{
		public PostHistoryService(
			ILogger<IPostHistoryRepository> logger,
			IPostHistoryRepository postHistoryRepository,
			IApiPostHistoryServerRequestModelValidator postHistoryModelValidator,
			IBOLPostHistoryMapper bolPostHistoryMapper,
			IDALPostHistoryMapper dalPostHistoryMapper)
			: base(logger,
			       postHistoryRepository,
			       postHistoryModelValidator,
			       bolPostHistoryMapper,
			       dalPostHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ac12683ca5449a211eac2cf29fdbd3a1</Hash>
</Codenesium>*/