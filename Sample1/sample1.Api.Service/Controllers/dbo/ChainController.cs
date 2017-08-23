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
	[RoutePrefix("api/chains")]
	public class ChainController: ChainControllerAbstract
	{
		public ChainController(
			ILogger logger,
			DbContext context,
			ChainRepository chainRepository,
			ChainModelValidator chainModelValidator
			) : base(logger,
			         context,
			         chainRepository,
			         chainModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>f0870e703e60ad97acc3a032d5eb1066</Hash>
</Codenesium>*/