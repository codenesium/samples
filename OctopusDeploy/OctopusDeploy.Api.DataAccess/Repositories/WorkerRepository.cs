using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class WorkerRepository: AbstractWorkerRepository, IWorkerRepository
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
    <Hash>4709b2268889f82043c65c7cdd9c71df</Hash>
</Codenesium>*/