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
    <Hash>fe7faba484ea2f6d0bc705722c6435f2</Hash>
</Codenesium>*/