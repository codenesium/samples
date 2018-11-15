using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class CommentService : AbstractCommentService, ICommentService
	{
		public CommentService(
			ILogger<ICommentRepository> logger,
			ICommentRepository commentRepository,
			IApiCommentServerRequestModelValidator commentModelValidator,
			IBOLCommentMapper bolCommentMapper,
			IDALCommentMapper dalCommentMapper)
			: base(logger,
			       commentRepository,
			       commentModelValidator,
			       bolCommentMapper,
			       dalCommentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>121e7c41b53d29b0b653a8fa56ecd5ea</Hash>
</Codenesium>*/