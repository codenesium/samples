using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>6901bc60038a8706b4a6221c6dd7c49b</Hash>
</Codenesium>*/