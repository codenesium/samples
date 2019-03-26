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
			IDALCommentMapper dalCommentMapper)
			: base(logger,
			       mediator,
			       commentRepository,
			       commentModelValidator,
			       dalCommentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2a4743a42d26ce321b292d76e075c2dc</Hash>
</Codenesium>*/