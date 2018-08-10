using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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
			IApiAdminModelMapper adminModelMapper
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
    <Hash>f831f151a5f424021b0aa2fedd1041eb</Hash>
</Codenesium>*/