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
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>15d9b1ea9f0ceb8ff7842b982e472920</Hash>
</Codenesium>*/