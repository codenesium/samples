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
	[Route("api/businessEntities")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(BusinessEntityFilter))]
	public class BusinessEntityController: AbstractBusinessEntityController
	{
		public BusinessEntityController(
			ILogger<BusinessEntityController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBusinessEntityRepository businessEntityRepository
			)
			: base(logger,
			       transactionCoordinator,
			       businessEntityRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>3e59ca3af1c533d6e25d5a35b0520c43</Hash>
</Codenesium>*/