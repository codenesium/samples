using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class WorkerTaskLeaseRepository : AbstractWorkerTaskLeaseRepository, IWorkerTaskLeaseRepository
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
    <Hash>dfc0cbc623e23ebfac63f554989658f2</Hash>
</Codenesium>*/