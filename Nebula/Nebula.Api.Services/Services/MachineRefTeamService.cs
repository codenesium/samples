using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial class MachineRefTeamService : AbstractMachineRefTeamService, IMachineRefTeamService
	{
		public MachineRefTeamService(
			ILogger<IMachineRefTeamRepository> logger,
			IMachineRefTeamRepository machineRefTeamRepository,
			IApiMachineRefTeamRequestModelValidator machineRefTeamModelValidator,
			IBOLMachineRefTeamMapper bolmachineRefTeamMapper,
			IDALMachineRefTeamMapper dalmachineRefTeamMapper
			)
			: base(logger,
			       machineRefTeamRepository,
			       machineRefTeamModelValidator,
			       bolmachineRefTeamMapper,
			       dalmachineRefTeamMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6b5569196e29ad8cfedda73d9e726ff0</Hash>
</Codenesium>*/