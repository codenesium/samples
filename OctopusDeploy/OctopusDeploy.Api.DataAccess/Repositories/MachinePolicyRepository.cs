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
	public partial class MachinePolicyRepository : AbstractMachinePolicyRepository, IMachinePolicyRepository
	{
		public MachinePolicyRepository(
			ILogger<MachinePolicyRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>88a5fef0cb61c4563fc07f59deee1883</Hash>
</Codenesium>*/