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
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service
{
	[RoutePrefix("api/organizations")]
	public class OrganizationsController: OrganizationsControllerAbstract
	{
		public OrganizationsController(
			ILogger logger,
			DbContext context,
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
    <Hash>7a219b7b725f29a34a46342d994016e0</Hash>
</Codenesium>*/