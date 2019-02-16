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
			IDALPostTypeMapper dalPostTypeMapper)
			: base(logger,
			       mediator,
			       postTypeRepository,
			       postTypeModelValidator,
			       dalPostTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c9a4a873f9c2c378e0af49f750b75cfa</Hash>
</Codenesium>*/