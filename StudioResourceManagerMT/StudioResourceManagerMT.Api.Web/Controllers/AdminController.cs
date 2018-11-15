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
	[Route("api/admins")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class AdminController : AbstractAdminController
	{
		public AdminController(
			ApiSettings settings,
			ILogger<AdminController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAdminService adminService,
			IApiAdminServerModelMapper adminModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       adminService,
			       adminModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7e7488c9e862737b31c5bb712439f79a</Hash>
</Codenesium>*/