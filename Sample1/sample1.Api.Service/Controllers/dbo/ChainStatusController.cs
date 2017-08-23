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
	[RoutePrefix("api/chainStatus")]
	public class ChainStatusController: ChainStatusControllerAbstract
	{
		public ChainStatusController(
			ILogger logger,
			DbContext context,
			ChainStatusRepository chainStatusRepository,
			ChainStatusModelValidator chainStatusModelValidator
			) : base(logger,
			         context,
			         chainStatusRepository,
			         chainStatusModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>85e46c503af473fecaa35662003cd232</Hash>
</Codenesium>*/