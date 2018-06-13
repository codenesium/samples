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
                        ILogger<WorkerPoolRepository> logger,
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
    <Hash>5c1645bbc4ba69001f56510ddac5929a</Hash>
</Codenesium>*/