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
			ApplicationContext context,
			ICultureRepository cultureRepository,
			ICultureModelValidator cultureModelValidator
			) : base(logger,
			         context,
			         cultureRepository,
			         cultureModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8a173482b28698a25d6abcf7f318945f</Hash>
</Codenesium>*/