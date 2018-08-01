using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class WorkerTaskLeaseRepository : AbstractWorkerTaskLeaseRepository, IWorkerTaskLeaseRepository
	{
		public WorkerTaskLeaseRepository(
			ILogger<WorkerTaskLeaseRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6af58b23d10e0ac0635ed6589720937b</Hash>
</Codenesium>*/