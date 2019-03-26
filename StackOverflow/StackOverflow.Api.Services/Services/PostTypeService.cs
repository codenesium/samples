using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class PostTypeService : AbstractPostTypeService, IPostTypeService
	{
		public PostTypeService(
			ILogger<IPostTypeRepository> logger,
			IMediator mediator,
			IPostTypeRepository postTypeRepository,
			IApiPostTypeServerRequestModelValidator postTypeModelValidator,
			IDALPostTypeMapper dalPostTypeMapper,
			IDALPostMapper dalPostMapper)
			: base(logger,
			       mediator,
			       postTypeRepository,
			       postTypeModelValidator,
			       dalPostTypeMapper,
			       dalPostMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>abd88dbb857d40499ab8d6daa3ac722d</Hash>
</Codenesium>*/