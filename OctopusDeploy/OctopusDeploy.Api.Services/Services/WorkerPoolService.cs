using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class WorkerPoolService: AbstractWorkerPoolService, IWorkerPoolService
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
                               dalworkerPoolMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>2e28f20d9ceda0d4a316808d974122b2</Hash>
</Codenesium>*/