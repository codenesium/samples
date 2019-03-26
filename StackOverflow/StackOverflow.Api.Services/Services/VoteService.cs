using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class VoteService : AbstractVoteService, IVoteService
	{
		public VoteService(
			ILogger<IVoteRepository> logger,
			IMediator mediator,
			IVoteRepository voteRepository,
			IApiVoteServerRequestModelValidator voteModelValidator,
			IDALVoteMapper dalVoteMapper)
			: base(logger,
			       mediator,
			       voteRepository,
			       voteModelValidator,
			       dalVoteMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>323825c2dc5439228ee58c113a41eeb5</Hash>
</Codenesium>*/