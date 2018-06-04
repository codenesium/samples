using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public class MachineRefTeamService: AbstractMachineRefTeamService, IMachineRefTeamService
	{
		public MachineRefTeamService(
			ILogger<MachineRefTeamRepository> logger,
			IMachineRefTeamRepository machineRefTeamRepository,
			IApiMachineRefTeamRequestModelValidator machineRefTeamModelValidator,
			IBOLMachineRefTeamMapper BOLmachineRefTeamMapper,
			IDALMachineRefTeamMapper DALmachineRefTeamMapper)
			: base(logger, machineRefTeamRepository,
			       machineRefTeamModelValidator,
			       BOLmachineRefTeamMapper,
			       DALmachineRefTeamMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>8879139435e8b20ca885a8a98c14e072</Hash>
</Codenesium>*/