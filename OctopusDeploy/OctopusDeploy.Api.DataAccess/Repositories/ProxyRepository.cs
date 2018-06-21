using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>7ec791fee2a1318f4b30949f399e02a5</Hash>
</Codenesium>*/