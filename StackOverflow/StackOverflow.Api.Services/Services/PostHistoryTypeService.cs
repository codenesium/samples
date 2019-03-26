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
			IDALPostHistoryTypeMapper dalPostHistoryTypeMapper,
			IDALPostHistoryMapper dalPostHistoryMapper)
			: base(logger,
			       mediator,
			       postHistoryTypeRepository,
			       postHistoryTypeModelValidator,
			       dalPostHistoryTypeMapper,
			       dalPostHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ef5caee338f8fa19a185ad0d9e441972</Hash>
</Codenesium>*/