using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class VoteService : AbstractVoteService, IVoteService
	{
		public VoteService(
			ILogger<IVoteRepository> logger,
			IVoteRepository voteRepository,
			IApiVoteServerRequestModelValidator voteModelValidator,
			IBOLVoteMapper bolVoteMapper,
			IDALVoteMapper dalVoteMapper)
			: base(logger,
			       voteRepository,
			       voteModelValidator,
			       bolVoteMapper,
			       dalVoteMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9b53bfb6822083e28b14b3365b78c4f0</Hash>
</Codenesium>*/