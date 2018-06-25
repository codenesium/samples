using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class WorkerPoolRepository : AbstractWorkerPoolRepository, IWorkerPoolRepository
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
    <Hash>6922a4f96fe540ca5bcb4716d42c08ca</Hash>
</Codenesium>*/