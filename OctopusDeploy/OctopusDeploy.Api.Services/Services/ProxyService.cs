using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
        public class ProxyService : AbstractProxyService, IProxyService
        {
                public ProxyService(
                        ILogger<IProxyRepository> logger,
                        IProxyRepository proxyRepository,
                        IApiProxyRequestModelValidator proxyModelValidator,
                        IBOLProxyMapper bolproxyMapper,
                        IDALProxyMapper dalproxyMapper
                        )
                        : base(logger,
                               proxyRepository,
                               proxyModelValidator,
                               bolproxyMapper,
                               dalproxyMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>9ca835f75c65c8c9ec85b15325362ad2</Hash>
</Codenesium>*/