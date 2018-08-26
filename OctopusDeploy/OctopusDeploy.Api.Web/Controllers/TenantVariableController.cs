using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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
	[Route("api/tenantVariables")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class TenantVariableController : AbstractTenantVariableController
	{
		public TenantVariableController(
			ApiSettings settings,
			ILogger<TenantVariableController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITenantVariableService tenantVariableService,
			IApiTenantVariableModelMapper tenantVariableModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       tenantVariableService,
			       tenantVariableModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6dfdcc910dd42de3fcd1b0912fd15bd1</Hash>
</Codenesium>*/