using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class VoteTypeService : AbstractVoteTypeService, IVoteTypeService
	{
		public VoteTypeService(
			ILogger<IVoteTypeRepository> logger,
			IVoteTypeRepository voteTypeRepository,
			IApiVoteTypeServerRequestModelValidator voteTypeModelValidator,
			IBOLVoteTypeMapper bolVoteTypeMapper,
			IDALVoteTypeMapper dalVoteTypeMapper)
			: base(logger,
			       voteTypeRepository,
			       voteTypeModelValidator,
			       bolVoteTypeMapper,
			       dalVoteTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>385d6248a836865b7c29d4b9e4c2f41d</Hash>
</Codenesium>*/