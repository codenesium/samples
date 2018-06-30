using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>b93234a7787e31a2e5a6565fb6e4d95d</Hash>
</Codenesium>*/