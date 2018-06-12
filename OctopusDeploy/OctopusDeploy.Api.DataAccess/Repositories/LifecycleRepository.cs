using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class LifecycleRepository: AbstractLifecycleRepository, ILifecycleRepository
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
    <Hash>465f294bcefd3e98a3132d30e87969da</Hash>
</Codenesium>*/