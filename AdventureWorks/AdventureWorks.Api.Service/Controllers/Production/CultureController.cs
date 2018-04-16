using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/cultures")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(CultureFilter))]
	public class CultureController: AbstractCultureController
	{
		public CultureController(
			ILogger<CultureController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICultureRepository cultureRepository
			)
			: base(logger,
			       transactionCoordinator,
			       cultureRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>63d41127e67f8c0abe660651c47079f8</Hash>
</Codenesium>*/