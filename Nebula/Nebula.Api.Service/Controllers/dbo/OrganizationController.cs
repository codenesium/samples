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
	public class OrganizationsController: OrganizationsControllerAbstract
	{
		public OrganizationsController(
			ILogger<OrganizationsController> logger,
			ApplicationContext context,
			OrganizationRepository organizationRepository,
			OrganizationModelValidator organizationModelValidator
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
    <Hash>270db6ce1bd91b45910758122000d4e7</Hash>
</Codenesium>*/