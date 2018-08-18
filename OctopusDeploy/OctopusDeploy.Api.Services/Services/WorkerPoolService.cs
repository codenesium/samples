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
	public partial class WorkerPoolService : AbstractWorkerPoolService, IWorkerPoolService
	{
		public WorkerPoolService(
			ILogger<IWorkerPoolRepository> logger,
			IWorkerPoolRepository workerPoolRepository,
			IApiWorkerPoolRequestModelValidator workerPoolModelValidator,
			IBOLWorkerPoolMapper bolworkerPoolMapper,
			IDALWorkerPoolMapper dalworkerPoolMapper
			)
			: base(logger,
			       workerPoolRepository,
			       workerPoolModelValidator,
			       bolworkerPoolMapper,
			       dalworkerPoolMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c59cbd18bdcb2e56b1a1874c0c4e4d52</Hash>
</Codenesium>*/