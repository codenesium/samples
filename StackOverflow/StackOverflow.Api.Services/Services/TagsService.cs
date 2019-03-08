using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class TagsService : AbstractTagsService, ITagsService
	{
		public TagsService(
			ILogger<ITagsRepository> logger,
			IMediator mediator,
			ITagsRepository tagsRepository,
			IApiTagsServerRequestModelValidator tagsModelValidator,
			IDALTagsMapper dalTagsMapper)
			: base(logger,
			       mediator,
			       tagsRepository,
			       tagsModelValidator,
			       dalTagsMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5c6587925a6ff855f49f07b230c5d566</Hash>
</Codenesium>*/