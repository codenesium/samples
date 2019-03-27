using MediatR;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class MachineRefTeamService : AbstractMachineRefTeamService, IMachineRefTeamService
	{
		public MachineRefTeamService(
			ILogger<IMachineRefTeamRepository> logger,
			IMediator mediator,
			IMachineRefTeamRepository machineRefTeamRepository,
			IApiMachineRefTeamServerRequestModelValidator machineRefTeamModelValidator,
			IDALMachineRefTeamMapper dalMachineRefTeamMapper)
			: base(logger,
			       mediator,
			       machineRefTeamRepository,
			       machineRefTeamModelValidator,
			       dalMachineRefTeamMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>de03d61011021b0ab7135c5bd3adff51</Hash>
</Codenesium>*/