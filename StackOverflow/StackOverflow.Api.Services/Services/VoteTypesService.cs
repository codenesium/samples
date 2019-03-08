using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class VoteTypesService : AbstractVoteTypesService, IVoteTypesService
	{
		public VoteTypesService(
			ILogger<IVoteTypesRepository> logger,
			IMediator mediator,
			IVoteTypesRepository voteTypesRepository,
			IApiVoteTypesServerRequestModelValidator voteTypesModelValidator,
			IDALVoteTypesMapper dalVoteTypesMapper,
			IDALVotesMapper dalVotesMapper)
			: base(logger,
			       mediator,
			       voteTypesRepository,
			       voteTypesModelValidator,
			       dalVoteTypesMapper,
			       dalVotesMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>239d545bd7f0682637ef7a32657a77f3</Hash>
</Codenesium>*/