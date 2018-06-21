using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class LifecycleRepository : AbstractLifecycleRepository, ILifecycleRepository
        {
                public LifecycleRepository(
                        ILogger<LifecycleRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>cdd36ceb06a0d21a12eff8975c9e01e9</Hash>
</Codenesium>*/