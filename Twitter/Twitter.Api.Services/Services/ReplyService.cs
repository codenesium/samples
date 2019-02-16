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
			IDALReplyMapper dalReplyMapper)
			: base(logger,
			       mediator,
			       replyRepository,
			       replyModelValidator,
			       dalReplyMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7b848393e6a30a36fa07800a765db131</Hash>
</Codenesium>*/