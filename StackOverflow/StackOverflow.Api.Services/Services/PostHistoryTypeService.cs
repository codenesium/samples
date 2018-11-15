using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class PostHistoryTypeService : AbstractPostHistoryTypeService, IPostHistoryTypeService
	{
		public PostHistoryTypeService(
			ILogger<IPostHistoryTypeRepository> logger,
			IPostHistoryTypeRepository postHistoryTypeRepository,
			IApiPostHistoryTypeServerRequestModelValidator postHistoryTypeModelValidator,
			IBOLPostHistoryTypeMapper bolPostHistoryTypeMapper,
			IDALPostHistoryTypeMapper dalPostHistoryTypeMapper)
			: base(logger,
			       postHistoryTypeRepository,
			       postHistoryTypeModelValidator,
			       bolPostHistoryTypeMapper,
			       dalPostHistoryTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>fcfc7c9ed25f2bf75ae163ee27ab01a9</Hash>
</Codenesium>*/