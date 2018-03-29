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
	[Route("api/chainStatus")]
	public class ChainStatusController: AbstractChainStatusController
	{
		public ChainStatusController(
			ILogger<ChainStatusController> logger,
			ApplicationContext context,
			IChainStatusRepository chainStatusRepository,
			IChainStatusModelValidator chainStatusModelValidator
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
    <Hash>c94658e612ab0976826f7144bfb3a599</Hash>
</Codenesium>*/