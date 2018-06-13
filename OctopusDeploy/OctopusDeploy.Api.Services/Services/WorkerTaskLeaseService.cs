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
        public class WorkerTaskLeaseService: AbstractWorkerTaskLeaseService, IWorkerTaskLeaseService
        {
                public WorkerTaskLeaseService(
                        ILogger<WorkerTaskLeaseRepository> logger,
                        IWorkerTaskLeaseRepository workerTaskLeaseRepository,
                        IApiWorkerTaskLeaseRequestModelValidator workerTaskLeaseModelValidator,
                        IBOLWorkerTaskLeaseMapper bolworkerTaskLeaseMapper,
                        IDALWorkerTaskLeaseMapper dalworkerTaskLeaseMapper

                        )
                        : base(logger,
                               workerTaskLeaseRepository,
                               workerTaskLeaseModelValidator,
                               bolworkerTaskLeaseMapper,
                               dalworkerTaskLeaseMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>72f4db42375195f1ff26f8abd642a711</Hash>
</Codenesium>*/