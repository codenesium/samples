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
	[RoutePrefix("api/teams")]
	public class TeamsController: TeamsControllerAbstract
	{
		public TeamsController(
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
    <Hash>cc36b394bca4848777db8d44b59bf228</Hash>
</Codenesium>*/