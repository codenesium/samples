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
	public class OrganizationsController: AbstractOrganizationsController
	{
		public OrganizationsController(
			ILogger<OrganizationsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IOrganizationRepository organizationRepository,
			IOrganizationModelValidator organizationModelValidator
			) : base(logger,
			         transactionCoordinator,
			         organizationRepository,
			         organizationModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>04811e8825a36cc3c1b8dbeac987127a</Hash>
</Codenesium>*/