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
	[RoutePrefix("api/clasps")]
	public class ClaspController: ClaspControllerAbstract
	{
		public ClaspController(
			ILogger logger,
			DbContext context,
			ClaspRepository claspRepository,
			ClaspModelValidator claspModelValidator
			) : base(logger,
			         context,
			         claspRepository,
			         claspModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>ea3f97d0a3fd972066f924e34c1a95d3</Hash>
</Codenesium>*/