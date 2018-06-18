using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ProxyService: AbstractProxyService, IProxyService
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
                               dalproxyMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>334b6d58d015925b7fff310765942eef</Hash>
</Codenesium>*/