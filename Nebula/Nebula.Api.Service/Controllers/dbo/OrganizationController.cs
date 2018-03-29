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
			ApplicationContext context,
			IOrganizationRepository organizationRepository,
			IOrganizationModelValidator organizationModelValidator
			) : base(logger,
			         context,
			         organizationRepository,
			         organizationModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>be7d53f8ae599f09ea99cda6253c6646</Hash>
</Codenesium>*/