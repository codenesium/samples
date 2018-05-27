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
	public class MachineRepository: AbstractMachineRepository, IMachineRepository
	{
		public MachineRepository(
			IDALMachineMapper mapper,
			ILogger<MachineRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>834292270e9f1ce5830bc25e40fb4c83</Hash>
</Codenesium>*/