using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class MachineService : AbstractMachineService, IMachineService
	{
		public MachineService(
			ILogger<IMachineRepository> logger,
			IMachineRepository machineRepository,
			IApiMachineServerRequestModelValidator machineModelValidator,
			IBOLMachineMapper bolMachineMapper,
			IDALMachineMapper dalMachineMapper,
			IBOLLinkMapper bolLinkMapper,
			IDALLinkMapper dalLinkMapper)
			: base(logger,
			       machineRepository,
			       machineModelValidator,
			       bolMachineMapper,
			       dalMachineMapper,
			       bolLinkMapper,
			       dalLinkMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ac663644b70263808e6dca84cb367437</Hash>
</Codenesium>*/