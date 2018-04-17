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
    <Hash>e316d78d6125e2f6252048c8b63f8b91</Hash>
</Codenesium>*/