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

namespace OctopusDeployNS.Api.Web
{
	[Route("api/tenants")]
	[ApiController]
	[ApiVersion("1.0")]
	public class TenantController : AbstractTenantController
	{
		public TenantController(
			ApiSettings settings,
			ILogger<TenantController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITenantService tenantService,
			IApiTenantModelMapper tenantModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       tenantService,
			       tenantModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b4782ee9a44d20b4f2810bf0cb57d2ef</Hash>
</Codenesium>*/