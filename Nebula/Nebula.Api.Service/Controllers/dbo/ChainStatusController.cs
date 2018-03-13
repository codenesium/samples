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
	public class ChainStatusController: ChainStatusControllerAbstract
	{
		public ChainStatusController(
			ILogger<ChainStatusController> logger,
			ApplicationContext context,
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
    <Hash>54a0068cd6c07e4a0f9df1726c738743</Hash>
</Codenesium>*/