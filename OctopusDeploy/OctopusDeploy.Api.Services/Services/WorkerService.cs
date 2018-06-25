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
    <Hash>4ec458ee3465020b0449f06a4dacb7b2</Hash>
</Codenesium>*/