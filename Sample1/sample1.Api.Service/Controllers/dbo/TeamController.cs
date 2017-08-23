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
	[RoutePrefix("api/teams")]
	public class TeamController: TeamControllerAbstract
	{
		public TeamController(
			ILogger logger,
			DbContext context,
			TeamRepository teamRepository,
			TeamModelValidator teamModelValidator
			) : base(logger,
			         context,
			         teamRepository,
			         teamModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>f59a3c4cf432dcb1a4c2bc55f268aee6</Hash>
</Codenesium>*/