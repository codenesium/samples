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
        public class WorkerTaskLeaseService : AbstractWorkerTaskLeaseService, IWorkerTaskLeaseService
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
    <Hash>1ef5b39bb9c8fa2b185a05954c509dff</Hash>
</Codenesium>*/