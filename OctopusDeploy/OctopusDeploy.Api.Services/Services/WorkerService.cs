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
	public partial class WorkerService : AbstractWorkerService, IWorkerService
	{
		public WorkerService(
			ILogger<IWorkerRepository> logger,
			IWorkerRepository workerRepository,
			IApiWorkerRequestModelValidator workerModelValidator,
			IBOLWorkerMapper bolworkerMapper,
			IDALWorkerMapper dalworkerMapper
			)
			: base(logger,
			       workerRepository,
			       workerModelValidator,
			       bolworkerMapper,
			       dalworkerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ad1dee3bfbe7c3d11719318c004b9628</Hash>
</Codenesium>*/