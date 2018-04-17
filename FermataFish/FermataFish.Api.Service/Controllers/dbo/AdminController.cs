using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.BusinessObjects;

namespace FermataFishNS.Api.Service
{
	[Route("api/admins")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class AdminController: AbstractAdminController
	{
		public AdminController(
			ILogger<AdminController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOAdmin adminManager
			)
			: base(logger,
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
    <Hash>dbceabc09ed98f8b166112cd16027f2a</Hash>
</Codenesium>*/