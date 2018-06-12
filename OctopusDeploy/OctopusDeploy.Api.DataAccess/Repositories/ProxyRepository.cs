using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ProxyRepository: AbstractProxyRepository, IProxyRepository
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
    <Hash>9e858179d5e82720749368aa49aa99f6</Hash>
</Codenesium>*/