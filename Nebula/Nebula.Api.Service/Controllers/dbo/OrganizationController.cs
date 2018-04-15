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
    <Hash>c2a83c796f25aef641891c788f5d35ae</Hash>
</Codenesium>*/