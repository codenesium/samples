using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.BusinessObjects;

namespace FermataFishNS.Api.Service
{
	[Route("api/admins")]
	[ApiVersion("1.0")]
	[Response]
	public class AdminController: AbstractAdminController
	{
		public AdminController(
			ServiceSettings settings,
			ILogger<AdminController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOAdmin adminManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       adminManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>654313adffede132a1be8958ee2c9411</Hash>
</Codenesium>*/