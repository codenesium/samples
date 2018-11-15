using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class ReplyService : AbstractReplyService, IReplyService
	{
		public ReplyService(
			ILogger<IReplyRepository> logger,
			IReplyRepository replyRepository,
			IApiReplyServerRequestModelValidator replyModelValidator,
			IBOLReplyMapper bolReplyMapper,
			IDALReplyMapper dalReplyMapper)
			: base(logger,
			       replyRepository,
			       replyModelValidator,
			       bolReplyMapper,
			       dalReplyMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>808a1e9d577c09aa7be01281b32aa718</Hash>
</Codenesium>*/