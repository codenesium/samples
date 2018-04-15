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
	public class AdminController: AbstractAdminController
	{
		public AdminController(
			ILogger<AdminController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAdminRepository adminRepository,
			IAdminModelValidator adminModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       adminRepository,
			       adminModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f9b2841fa6ac29eea365b364c3643cc9</Hash>
</Codenesium>*/