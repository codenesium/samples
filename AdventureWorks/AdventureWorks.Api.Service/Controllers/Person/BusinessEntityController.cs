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
    <Hash>1b810c12f4fc79bab30f4e0e97c1a570</Hash>
</Codenesium>*/