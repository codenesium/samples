using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class WorkerPoolRepository: AbstractWorkerPoolRepository, IWorkerPoolRepository
        {
                public WorkerPoolRepository(
                        ILogger<WorkerPoolRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>a106e64ea3bc4725a2670b22881454b2</Hash>
</Codenesium>*/