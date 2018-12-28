using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class TagService : AbstractTagService, ITagService
	{
		public TagService(
			ILogger<ITagRepository> logger,
			IMediator mediator,
			ITagRepository tagRepository,
			IApiTagServerRequestModelValidator tagModelValidator,
			IBOLTagMapper bolTagMapper,
			IDALTagMapper dalTagMapper)
			: base(logger,
			       mediator,
			       tagRepository,
			       tagModelValidator,
			       bolTagMapper,
			       dalTagMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5f7bbe5a51f9f274e7004e93b53b2354</Hash>
</Codenesium>*/