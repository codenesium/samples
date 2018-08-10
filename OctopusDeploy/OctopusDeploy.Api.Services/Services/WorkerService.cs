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
    <Hash>b52742237b6e04d53205b6e239607a36</Hash>
</Codenesium>*/