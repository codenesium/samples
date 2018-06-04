using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
	public class MachineRefTeamRepository: AbstractMachineRefTeamRepository, IMachineRefTeamRepository
	{
		public MachineRefTeamRepository(
			ILogger<MachineRefTeamRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>c1b3f45c4a485096f387b9bcd89ff864</Hash>
</Codenesium>*/