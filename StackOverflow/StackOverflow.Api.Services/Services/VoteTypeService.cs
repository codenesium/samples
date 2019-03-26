using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class VoteTypeService : AbstractVoteTypeService, IVoteTypeService
	{
		public VoteTypeService(
			ILogger<IVoteTypeRepository> logger,
			IMediator mediator,
			IVoteTypeRepository voteTypeRepository,
			IApiVoteTypeServerRequestModelValidator voteTypeModelValidator,
			IDALVoteTypeMapper dalVoteTypeMapper,
			IDALVoteMapper dalVoteMapper)
			: base(logger,
			       mediator,
			       voteTypeRepository,
			       voteTypeModelValidator,
			       dalVoteTypeMapper,
			       dalVoteMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1b9f7033a82070f9c4b80f8b9fbd03c3</Hash>
</Codenesium>*/