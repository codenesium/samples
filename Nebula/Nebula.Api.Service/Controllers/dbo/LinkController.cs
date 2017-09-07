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
	[RoutePrefix("api/links")]
	public class LinksController: LinksControllerAbstract
	{
		public LinksController(
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
    <Hash>308e48449fc9150948b501c1c17b3596</Hash>
</Codenesium>*/