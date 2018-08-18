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
    <Hash>45836731a3faf03161cbf9f99751a290</Hash>
</Codenesium>*/