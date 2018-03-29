using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service
{
	[Route("api/chains")]
	public class ChainsController: AbstractChainsController
	{
		public ChainsController(
			ILogger<ChainsController> logger,
			ApplicationContext context,
			IChainRepository chainRepository,
			IChainModelValidator chainModelValidator
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
    <Hash>2cf6a92e6ca1f0dd2a321672f62880d7</Hash>
</Codenesium>*/