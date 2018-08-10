using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/proxies")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ProxyController : AbstractProxyController
	{
		public ProxyController(
			ApiSettings settings,
			ILogger<ProxyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProxyService proxyService,
			IApiProxyModelMapper proxyModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       proxyService,
			       proxyModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>86f44740aa8d556e96828d02863266eb</Hash>
</Codenesium>*/