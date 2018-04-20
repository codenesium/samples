using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/businessEntities")]
	[ApiVersion("1.0")]
	[Response]
	public class BusinessEntityController: AbstractBusinessEntityController
	{
		public BusinessEntityController(
			ServiceSettings settings,
			ILogger<BusinessEntityController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOBusinessEntity businessEntityManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       businessEntityManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>32969b6b4b6ed9bf4df507a179ad3ccc</Hash>
</Codenesium>*/