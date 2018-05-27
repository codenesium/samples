using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public class MachineRefTeamRepository: AbstractMachineRefTeamRepository, IMachineRefTeamRepository
	{
		public MachineRefTeamRepository(
			IDALMachineRefTeamMapper mapper,
			ILogger<MachineRefTeamRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>27777883aa428b48c94339699435ac5c</Hash>
</Codenesium>*/