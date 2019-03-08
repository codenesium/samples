using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class CommentsService : AbstractCommentsService, ICommentsService
	{
		public CommentsService(
			ILogger<ICommentsRepository> logger,
			IMediator mediator,
			ICommentsRepository commentsRepository,
			IApiCommentsServerRequestModelValidator commentsModelValidator,
			IDALCommentsMapper dalCommentsMapper)
			: base(logger,
			       mediator,
			       commentsRepository,
			       commentsModelValidator,
			       dalCommentsMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d77f44fc3d1419f8187ee067b5b2c703</Hash>
</Codenesium>*/