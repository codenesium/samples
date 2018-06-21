using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class WorkerPoolRepository : AbstractWorkerPoolRepository, IWorkerPoolRepository
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
    <Hash>d308d8864416e0827cf8e5bfeb027f00</Hash>
</Codenesium>*/