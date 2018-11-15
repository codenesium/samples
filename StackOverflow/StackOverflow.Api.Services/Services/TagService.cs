using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class TagService : AbstractTagService, ITagService
	{
		public TagService(
			ILogger<ITagRepository> logger,
			ITagRepository tagRepository,
			IApiTagServerRequestModelValidator tagModelValidator,
			IBOLTagMapper bolTagMapper,
			IDALTagMapper dalTagMapper)
			: base(logger,
			       tagRepository,
			       tagModelValidator,
			       bolTagMapper,
			       dalTagMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>64f49853e14aa03a774dcd7651a9ad3b</Hash>
</Codenesium>*/