using Codenesium.DataConversionExtensions.AspNetCore;
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
        public class WorkerPoolService : AbstractWorkerPoolService, IWorkerPoolService
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
    <Hash>58839c55e4367a93822bdff0a3b21110</Hash>
</Codenesium>*/