using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.BusinessObjects;

namespace NebulaNS.Api.Service
{
	[Route("api/organizations")]
	[ApiVersion("1.0")]
	public class OrganizationController: AbstractOrganizationController
	{
		public OrganizationController(
			ILogger<OrganizationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOOrganization organizationManager
			)
			: base(logger,
			       transactionCoordinator,
			       organizationManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4496351bbbf8f61d2fa5490ce73e471d</Hash>
</Codenesium>*/