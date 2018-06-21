using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class WorkerRepository : AbstractWorkerRepository, IWorkerRepository
        {
                public WorkerRepository(
                        ILogger<WorkerRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e6dd1fea9673cb73dd6882e1fb10d520</Hash>
</Codenesium>*/