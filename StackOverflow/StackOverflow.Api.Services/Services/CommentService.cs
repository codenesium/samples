using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class CommentService : AbstractCommentService, ICommentService
	{
		public CommentService(
			ILogger<ICommentRepository> logger,
			IMediator mediator,
			ICommentRepository commentRepository,
			IApiCommentServerRequestModelValidator commentModelValidator,
			IBOLCommentMapper bolCommentMapper,
			IDALCommentMapper dalCommentMapper)
			: base(logger,
			       mediator,
			       commentRepository,
			       commentModelValidator,
			       bolCommentMapper,
			       dalCommentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>73a2b9afa0714905bacc46c1bbf184f6</Hash>
</Codenesium>*/