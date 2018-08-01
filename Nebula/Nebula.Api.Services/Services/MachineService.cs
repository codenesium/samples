using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
	public partial class MachineService : AbstractMachineService, IMachineService
	{
		public MachineService(
			ILogger<IMachineRepository> logger,
			IMachineRepository machineRepository,
			IApiMachineRequestModelValidator machineModelValidator,
			IBOLMachineMapper bolmachineMapper,
			IDALMachineMapper dalmachineMapper,
			IBOLLinkMapper bolLinkMapper,
			IDALLinkMapper dalLinkMapper,
			IBOLMachineRefTeamMapper bolMachineRefTeamMapper,
			IDALMachineRefTeamMapper dalMachineRefTeamMapper
			)
			: base(logger,
			       machineRepository,
			       machineModelValidator,
			       bolmachineMapper,
			       dalmachineMapper,
			       bolLinkMapper,
			       dalLinkMapper,
			       bolMachineRefTeamMapper,
			       dalMachineRefTeamMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5c7485cb420c4d2cd8bd8e04e3be0092</Hash>
</Codenesium>*/