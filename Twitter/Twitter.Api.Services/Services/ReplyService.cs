using MediatR;
using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class ReplyService : AbstractReplyService, IReplyService
	{
		public ReplyService(
			ILogger<IReplyRepository> logger,
			IMediator mediator,
			IReplyRepository replyRepository,
			IApiReplyServerRequestModelValidator replyModelValidator,
			IBOLReplyMapper bolReplyMapper,
			IDALReplyMapper dalReplyMapper)
			: base(logger,
			       mediator,
			       replyRepository,
			       replyModelValidator,
			       bolReplyMapper,
			       dalReplyMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>416b2c75a74b702a3efed01d8f4a3b9a</Hash>
</Codenesium>*/