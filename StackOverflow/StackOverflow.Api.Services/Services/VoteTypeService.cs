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
			IBOLVoteTypeMapper bolVoteTypeMapper,
			IDALVoteTypeMapper dalVoteTypeMapper)
			: base(logger,
			       mediator,
			       voteTypeRepository,
			       voteTypeModelValidator,
			       bolVoteTypeMapper,
			       dalVoteTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>64d4f6876f7fb6a18e75054036f001b9</Hash>
</Codenesium>*/