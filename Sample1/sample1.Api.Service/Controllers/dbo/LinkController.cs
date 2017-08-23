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
	[RoutePrefix("api/links")]
	public class LinkController: LinkControllerAbstract
	{
		public LinkController(
			ILogger logger,
			DbContext context,
			LinkRepository linkRepository,
			LinkModelValidator linkModelValidator
			) : base(logger,
			         context,
			         linkRepository,
			         linkModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>ea913c59d3ddb4a0f6e016c1fc5d74c5</Hash>
</Codenesium>*/