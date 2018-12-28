using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class PostHistoryTypeService : AbstractPostHistoryTypeService, IPostHistoryTypeService
	{
		public PostHistoryTypeService(
			ILogger<IPostHistoryTypeRepository> logger,
			IMediator mediator,
			IPostHistoryTypeRepository postHistoryTypeRepository,
			IApiPostHistoryTypeServerRequestModelValidator postHistoryTypeModelValidator,
			IBOLPostHistoryTypeMapper bolPostHistoryTypeMapper,
			IDALPostHistoryTypeMapper dalPostHistoryTypeMapper)
			: base(logger,
			       mediator,
			       postHistoryTypeRepository,
			       postHistoryTypeModelValidator,
			       bolPostHistoryTypeMapper,
			       dalPostHistoryTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>309d47cf69ee0165dbd176dd8c3523ed</Hash>
</Codenesium>*/