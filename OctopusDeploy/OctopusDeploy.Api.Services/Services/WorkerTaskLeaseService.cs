using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial class WorkerTaskLeaseService : AbstractWorkerTaskLeaseService, IWorkerTaskLeaseService
	{
		public WorkerTaskLeaseService(
			ILogger<IWorkerTaskLeaseRepository> logger,
			IWorkerTaskLeaseRepository workerTaskLeaseRepository,
			IApiWorkerTaskLeaseRequestModelValidator workerTaskLeaseModelValidator,
			IBOLWorkerTaskLeaseMapper bolworkerTaskLeaseMapper,
			IDALWorkerTaskLeaseMapper dalworkerTaskLeaseMapper
			)
			: base(logger,
			       workerTaskLeaseRepository,
			       workerTaskLeaseModelValidator,
			       bolworkerTaskLeaseMapper,
			       dalworkerTaskLeaseMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4f00489e56816358f6bd6668a9153bd1</Hash>
</Codenesium>*/