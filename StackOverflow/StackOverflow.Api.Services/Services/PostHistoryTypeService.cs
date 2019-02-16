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
			IDALPostHistoryTypeMapper dalPostHistoryTypeMapper)
			: base(logger,
			       mediator,
			       postHistoryTypeRepository,
			       postHistoryTypeModelValidator,
			       dalPostHistoryTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>76f71d616704d3539f52f30f67e6936f</Hash>
</Codenesium>*/