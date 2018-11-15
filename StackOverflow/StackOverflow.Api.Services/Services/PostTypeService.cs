using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class PostTypeService : AbstractPostTypeService, IPostTypeService
	{
		public PostTypeService(
			ILogger<IPostTypeRepository> logger,
			IPostTypeRepository postTypeRepository,
			IApiPostTypeServerRequestModelValidator postTypeModelValidator,
			IBOLPostTypeMapper bolPostTypeMapper,
			IDALPostTypeMapper dalPostTypeMapper)
			: base(logger,
			       postTypeRepository,
			       postTypeModelValidator,
			       bolPostTypeMapper,
			       dalPostTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2a86e686eca43fc70c08c86cbeddae54</Hash>
</Codenesium>*/