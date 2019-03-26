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
			IDALTagMapper dalTagMapper)
			: base(logger,
			       mediator,
			       tagRepository,
			       tagModelValidator,
			       dalTagMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b31872cf60e4ed19bd8564654aa9acf8</Hash>
</Codenesium>*/