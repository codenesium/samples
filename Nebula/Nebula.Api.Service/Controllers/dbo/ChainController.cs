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
    <Hash>b451f08480cea27c9b886dd8b482d1c5</Hash>
</Codenesium>*/