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
        public class WorkerService : AbstractWorkerService, IWorkerService
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
    <Hash>f1ee92c56255635b13527a25a58cd29d</Hash>
</Codenesium>*/