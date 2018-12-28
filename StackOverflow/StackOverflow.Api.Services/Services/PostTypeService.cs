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
			IBOLPostTypeMapper bolPostTypeMapper,
			IDALPostTypeMapper dalPostTypeMapper)
			: base(logger,
			       mediator,
			       postTypeRepository,
			       postTypeModelValidator,
			       bolPostTypeMapper,
			       dalPostTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7131c0ab68633a70b8cae3049b4915ee</Hash>
</Codenesium>*/