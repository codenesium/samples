using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
	public class MachineRepository: AbstractMachineRepository, IMachineRepository
	{
		public MachineRepository(
			ILogger<MachineRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>0775c83111dc1deec2ae8795baeb0925</Hash>
</Codenesium>*/