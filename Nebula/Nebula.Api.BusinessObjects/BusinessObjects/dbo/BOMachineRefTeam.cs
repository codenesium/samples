using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class BOMachineRefTeam: AbstractBOMachineRefTeam, IBOMachineRefTeam
	{
		public BOMachineRefTeam(
			ILogger<MachineRefTeamRepository> logger,
			IMachineRefTeamRepository machineRefTeamRepository,
			IApiMachineRefTeamRequestModelValidator machineRefTeamModelValidator,
			IBOLMachineRefTeamMapper machineRefTeamMapper)
			: base(logger, machineRefTeamRepository, machineRefTeamModelValidator, machineRefTeamMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>bebdcb9733265af1b0763aad6de042b2</Hash>
</Codenesium>*/