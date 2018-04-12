using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	[Route("api/admins")]
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
    <Hash>f5afff080eeeca3caf4e17c95548138f</Hash>
</Codenesium>*/