using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class MachineRepository : AbstractMachineRepository, IMachineRepository
	{
		public MachineRepository(
			ILogger<MachineRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ebc73decf5618743e0bdb0bfa0d7027c</Hash>
</Codenesium>*/