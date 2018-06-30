using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class ProxyRepository : AbstractProxyRepository, IProxyRepository
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
    <Hash>a2d0c4ece478bbc874a6f619b78db7b5</Hash>
</Codenesium>*/