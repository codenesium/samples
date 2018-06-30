using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class LifecycleRepository : AbstractLifecycleRepository, ILifecycleRepository
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
    <Hash>5595ff04e2ef61ec7178a6486a78662b</Hash>
</Codenesium>*/