using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	[Route("api/organizations")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(OrganizationFilter))]
	public class OrganizationController: AbstractOrganizationController
	{
		public OrganizationController(
			ILogger<OrganizationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IOrganizationRepository organizationRepository
			)
			: base(logger,
			       transactionCoordinator,
			       organizationRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>799ce8b7743e2c657cc8221be6eac51d</Hash>
</Codenesium>*/