using Codenesium.DataConversionExtensions;
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
    <Hash>1c527eb54a0b3a81043e84cf9a812666</Hash>
</Codenesium>*/