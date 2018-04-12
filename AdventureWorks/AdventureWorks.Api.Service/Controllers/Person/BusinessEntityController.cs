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
	[Route("api/businessEntities")]
	public class BusinessEntityController: AbstractBusinessEntityController
	{
		public BusinessEntityController(
			ILogger<BusinessEntityController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBusinessEntityRepository businessEntityRepository,
			IBusinessEntityModelValidator businessEntityModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       businessEntityRepository,
			       businessEntityModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>3ebbe036e3e9162aeaa76031c47167ed</Hash>
</Codenesium>*/