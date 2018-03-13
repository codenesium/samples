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
	public class ChainsController: ChainsControllerAbstract
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
    <Hash>814b5df555f69dbb991d54a1a2afb207</Hash>
</Codenesium>*/