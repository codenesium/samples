using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class WorkerRepository : AbstractWorkerRepository, IWorkerRepository
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
    <Hash>dfeb7de1c4bef33c80ff55ba73fa94dd</Hash>
</Codenesium>*/