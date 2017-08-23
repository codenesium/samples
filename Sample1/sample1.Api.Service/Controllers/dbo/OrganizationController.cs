using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using sample1NS.Api.Contracts;
using sample1NS.Api.DataAccess;
namespace sample1NS.Api.Service
{
	[RoutePrefix("api/organizations")]
	public class OrganizationController: OrganizationControllerAbstract
	{
		public OrganizationController(
			ILogger logger,
			DbContext context,
			OrganizationRepository organizationRepository,
			OrganizationModelValidator organizationModelValidator
			) : base(logger,
			         context,
			         organizationRepository,
			         organizationModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>aecab3c52588bdfefe090f6e88779e18</Hash>
</Codenesium>*/