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
			IApiMachineRefTeamModelValidator machineRefTeamModelValidator)
			: base(logger, machineRefTeamRepository, machineRefTeamModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>79047dbdc2064775c7f43c636b5d0d5a</Hash>
</Codenesium>*/