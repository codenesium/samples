using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class WorkerRepository : AbstractWorkerRepository, IWorkerRepository
	{
		public WorkerRepository(
			ILogger<WorkerRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>250b12f586716f8e228524fa51c43c0a</Hash>
</Codenesium>*/