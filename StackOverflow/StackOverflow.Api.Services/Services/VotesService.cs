using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class VotesService : AbstractVotesService, IVotesService
	{
		public VotesService(
			ILogger<IVotesRepository> logger,
			IMediator mediator,
			IVotesRepository votesRepository,
			IApiVotesServerRequestModelValidator votesModelValidator,
			IDALVotesMapper dalVotesMapper)
			: base(logger,
			       mediator,
			       votesRepository,
			       votesModelValidator,
			       dalVotesMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5927450d58b56569aa2c4e50bb7cf1b0</Hash>
</Codenesium>*/