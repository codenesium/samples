using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial class ProxyService : AbstractProxyService, IProxyService
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
    <Hash>c2f50cc64bdfcfaa7d5fe81aff89ea39</Hash>
</Codenesium>*/