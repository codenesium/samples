using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ProxyRepository : AbstractProxyRepository, IProxyRepository
        {
                public ProxyRepository(
                        ILogger<ProxyRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>d4e11654cd56fc5edd90d5db6cfbc4a7</Hash>
</Codenesium>*/