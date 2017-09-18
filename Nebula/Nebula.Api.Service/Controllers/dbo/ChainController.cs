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
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e179882d578609fe78ba4e4373d2a610</Hash>
</Codenesium>*/