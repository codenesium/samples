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
			IDALChainMapper dalChainMapper,
			IDALMachineRefTeamMapper dalMachineRefTeamMapper)
			: base(logger,
			       mediator,
			       teamRepository,
			       teamModelValidator,
			       dalTeamMapper,
			       dalChainMapper,
			       dalMachineRefTeamMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1ad01f054ba5052c93230160c204eac2</Hash>
</Codenesium>*/