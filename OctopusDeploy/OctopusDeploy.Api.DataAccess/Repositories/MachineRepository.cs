using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>625193a933d2e3e24e20b7cee854ddda</Hash>
</Codenesium>*/