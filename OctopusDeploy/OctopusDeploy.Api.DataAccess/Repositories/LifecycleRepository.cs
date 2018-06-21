using Codenesium.DataConversionExtensions;
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
    <Hash>dc4577791f37142c6984027b2c8b00fb</Hash>
</Codenesium>*/