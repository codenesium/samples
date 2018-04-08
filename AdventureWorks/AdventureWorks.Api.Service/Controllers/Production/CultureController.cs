using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	[Route("api/cultures")]
	public class CulturesController: AbstractCulturesController
	{
		public CulturesController(
			ILogger<CulturesController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICultureRepository cultureRepository,
			ICultureModelValidator cultureModelValidator
			) : base(logger,
			         transactionCoordinator,
			         cultureRepository,
			         cultureModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f2c41e05d8c11de60ab8a66a64c94a19</Hash>
</Codenesium>*/