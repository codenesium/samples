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
    <Hash>b2ea70e9b1e4fc4d0d07b0188ae57dbd</Hash>
</Codenesium>*/