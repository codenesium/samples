using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>cbe7b8cb09f15f558ce1fa188a9b5b49</Hash>
</Codenesium>*/