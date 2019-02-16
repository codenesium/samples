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
			IDALVoteTypeMapper dalVoteTypeMapper)
			: base(logger,
			       mediator,
			       voteTypeRepository,
			       voteTypeModelValidator,
			       dalVoteTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f66996d5ca34ef09e80dd5a88d55bc9a</Hash>
</Codenesium>*/