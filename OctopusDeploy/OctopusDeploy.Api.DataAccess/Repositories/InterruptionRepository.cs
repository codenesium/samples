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
    <Hash>119b56b3ee9b24d6bb055f022d294fd5</Hash>
</Codenesium>*/