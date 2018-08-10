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
	public partial class WorkerPoolRepository : AbstractWorkerPoolRepository, IWorkerPoolRepository
	{
		public WorkerPoolRepository(
			ILogger<WorkerPoolRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4b63111e32f9e661acce895af14d90fa</Hash>
</Codenesium>*/