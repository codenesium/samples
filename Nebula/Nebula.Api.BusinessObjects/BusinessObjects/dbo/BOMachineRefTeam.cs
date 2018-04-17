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
			IMachineRefTeamModelValidator machineRefTeamModelValidator)
			: base(logger, machineRefTeamRepository, machineRefTeamModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>2d1aca8205be163e048a1e5b2e8f7812</Hash>
</Codenesium>*/