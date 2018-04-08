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
			ITransactionCoordinator transactionCoordinator,
			IChainRepository chainRepository,
			IChainModelValidator chainModelValidator
			) : base(logger,
			         transactionCoordinator,
			         chainRepository,
			         chainModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>32f5a9e882c80ca547a3c654b71181c9</Hash>
</Codenesium>*/