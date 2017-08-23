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
	[RoutePrefix("api/linkStatus")]
	public class LinkStatusController: LinkStatusControllerAbstract
	{
		public LinkStatusController(
			ILogger logger,
			DbContext context,
			LinkStatusRepository linkStatusRepository,
			LinkStatusModelValidator linkStatusModelValidator
			) : base(logger,
			         context,
			         linkStatusRepository,
			         linkStatusModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>3e044134c9b36f0222ff120ac390b1e7</Hash>
</Codenesium>*/