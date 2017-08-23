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
	[RoutePrefix("api/linkLogs")]
	public class LinkLogController: LinkLogControllerAbstract
	{
		public LinkLogController(
			ILogger logger,
			DbContext context,
			LinkLogRepository linkLogRepository,
			LinkLogModelValidator linkLogModelValidator
			) : base(logger,
			         context,
			         linkLogRepository,
			         linkLogModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>4e30afccde449b75a56eaf5d390a00b9</Hash>
</Codenesium>*/