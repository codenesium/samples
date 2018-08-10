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
    <Hash>73861f2c3c74eb9a79c9b0634c4cf968</Hash>
</Codenesium>*/