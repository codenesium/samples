using MediatR;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class MachineService : AbstractMachineService, IMachineService
	{
		public MachineService(
			ILogger<IMachineRepository> logger,
			IMediator mediator,
			IMachineRepository machineRepository,
			IApiMachineServerRequestModelValidator machineModelValidator,
			IDALMachineMapper dalMachineMapper,
			IDALLinkMapper dalLinkMapper,
			IDALMachineRefTeamMapper dalMachineRefTeamMapper)
			: base(logger,
			       mediator,
			       machineRepository,
			       machineModelValidator,
			       dalMachineMapper,
			       dalLinkMapper,
			       dalMachineRefTeamMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3c123fc7d427db1c8586f620a8f227a8</Hash>
</Codenesium>*/