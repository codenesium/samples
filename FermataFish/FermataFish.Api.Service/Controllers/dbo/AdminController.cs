using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	[Route("api/admins")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(AdminFilter))]
	public class AdminController: AbstractAdminController
	{
		public AdminController(
			ILogger<AdminController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAdminRepository adminRepository
			)
			: base(logger,
			       transactionCoordinator,
			       adminRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>308f990691e81b795f0d6638b0f7d62e</Hash>
</Codenesium>*/