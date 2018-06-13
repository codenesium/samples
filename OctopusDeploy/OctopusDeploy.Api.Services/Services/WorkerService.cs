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
        public class WorkerService: AbstractWorkerService, IWorkerService
        {
                public WorkerService(
                        ILogger<WorkerRepository> logger,
                        IWorkerRepository workerRepository,
                        IApiWorkerRequestModelValidator workerModelValidator,
                        IBOLWorkerMapper bolworkerMapper,
                        IDALWorkerMapper dalworkerMapper

                        )
                        : base(logger,
                               workerRepository,
                               workerModelValidator,
                               bolworkerMapper,
                               dalworkerMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>c6d26779cb1258c4f0690a1cf6a1d09a</Hash>
</Codenesium>*/