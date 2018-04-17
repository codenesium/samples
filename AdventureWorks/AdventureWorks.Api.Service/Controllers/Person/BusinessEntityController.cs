using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/businessEntities")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class BusinessEntityController: AbstractBusinessEntityController
	{
		public BusinessEntityController(
			ILogger<BusinessEntityController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOBusinessEntity businessEntityManager
			)
			: base(logger,
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
    <Hash>d26e0895b713072f4814aacd73ab956c</Hash>
</Codenesium>*/