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
	public partial class InterruptionRepository : AbstractInterruptionRepository, IInterruptionRepository
	{
		public InterruptionRepository(
			ILogger<InterruptionRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c625a3c2c334f8a69b2f924ba9f2b0d4</Hash>
</Codenesium>*/