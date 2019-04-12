using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Web
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
			IApiTenantServerModelMapper tenantModelMapper
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
    <Hash>ef4ce99e6d0b1077c6929768de068b7f</Hash>
</Codenesium>*/