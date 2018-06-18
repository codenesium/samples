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
                               dalworkerMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>d1b4b19cd79aff6e226e9bad91758008</Hash>
</Codenesium>*/