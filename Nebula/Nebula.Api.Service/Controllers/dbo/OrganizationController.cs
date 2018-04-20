using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.BusinessObjects;

namespace NebulaNS.Api.Service
{
	[Route("api/organizations")]
	[ApiVersion("1.0")]
	[Response]
	public class OrganizationController: AbstractOrganizationController
	{
		public OrganizationController(
			ServiceSettings settings,
			ILogger<OrganizationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOOrganization organizationManager
			)
			: base(settings,
			       logger,
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
    <Hash>4cba1cd20cbaaf53984b040dfefd04c5</Hash>
</Codenesium>*/