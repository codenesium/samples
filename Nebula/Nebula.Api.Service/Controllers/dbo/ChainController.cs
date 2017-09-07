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
	[RoutePrefix("api/chains")]
	public class ChainsController: ChainsControllerAbstract
	{
		public ChainsController(
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
    <Hash>1799ef0506d74d962df88ca781b73cfc</Hash>
</Codenesium>*/