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
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ac66b8bcb9328b602abfd4524d0efeb2</Hash>
</Codenesium>*/