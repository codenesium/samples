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
			IDALLinkMapper dalLinkMapper)
			: base(logger,
			       mediator,
			       machineRepository,
			       machineModelValidator,
			       dalMachineMapper,
			       dalLinkMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8dd259ac2b7e4bcafb8e1e2d208ebb36</Hash>
</Codenesium>*/