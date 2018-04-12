using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	[Route("api/organizations")]
	public class OrganizationController: AbstractOrganizationController
	{
		public OrganizationController(
			ILogger<OrganizationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IOrganizationRepository organizationRepository,
			IOrganizationModelValidator organizationModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       organizationRepository,
			       organizationModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>178cd40c377c906e56032c87c6244d6f</Hash>
</Codenesium>*/