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
    <Hash>e40fe88a3bd6570cb264ed021220ab84</Hash>
</Codenesium>*/