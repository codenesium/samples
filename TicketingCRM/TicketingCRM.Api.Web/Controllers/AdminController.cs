using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
	[Route("api/admins")]
	[ApiController]
	[ApiVersion("1.0")]

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
    <Hash>f7920982e62d97910912dcf2a4fcb5e6</Hash>
</Codenesium>*/