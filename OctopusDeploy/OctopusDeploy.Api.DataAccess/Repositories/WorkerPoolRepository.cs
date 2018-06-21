using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>df2c137538ae97512a2904843d130899</Hash>
</Codenesium>*/