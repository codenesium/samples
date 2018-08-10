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
    <Hash>ec816adf85bc9d7b1886b7d0a871cecb</Hash>
</Codenesium>*/