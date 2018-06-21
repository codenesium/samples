using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class WorkerTaskLeaseRepository : AbstractWorkerTaskLeaseRepository, IWorkerTaskLeaseRepository
        {
                public WorkerTaskLeaseRepository(
                        ILogger<WorkerTaskLeaseRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e389e3cf8bf32d9bdb861d51c355a26a</Hash>
</Codenesium>*/