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
	[RoutePrefix("api/linkLogs")]
	public class LinkLogsController: LinkLogsControllerAbstract
	{
		public LinkLogsController(
			ILogger logger,
			DbContext context,
			LinkLogRepository linkLogRepository,
			LinkLogModelValidator linkLogModelValidator
			) : base(logger,
			         context,
			         linkLogRepository,
			         linkLogModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>785a88bd01718060c37322119e5213e2</Hash>
</Codenesium>*/