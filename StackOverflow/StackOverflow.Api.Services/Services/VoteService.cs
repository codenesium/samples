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
			IBOLVoteMapper bolVoteMapper,
			IDALVoteMapper dalVoteMapper)
			: base(logger,
			       mediator,
			       voteRepository,
			       voteModelValidator,
			       bolVoteMapper,
			       dalVoteMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>03ed419e59f1d406a0d8fa5a3b5c36b0</Hash>
</Codenesium>*/