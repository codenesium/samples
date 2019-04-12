using MediatR;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class TeamService : AbstractTeamService, ITeamService
	{
		public TeamService(
			ILogger<ITeamRepository> logger,
			IMediator mediator,
			ITeamRepository teamRepository,
			IApiTeamServerRequestModelValidator teamModelValidator,
			IDALTeamMapper dalTeamMapper,
			IDALChainMapper dalChainMapper)
			: base(logger,
			       mediator,
			       teamRepository,
			       teamModelValidator,
			       dalTeamMapper,
			       dalChainMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>191521dd2ab89125b2c4622d5cab7fa1</Hash>
</Codenesium>*/