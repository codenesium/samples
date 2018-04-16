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
	[Route("api/businessEntityContacts")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(BusinessEntityContactFilter))]
	public class BusinessEntityContactController: AbstractBusinessEntityContactController
	{
		public BusinessEntityContactController(
			ILogger<BusinessEntityContactController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBusinessEntityContactRepository businessEntityContactRepository
			)
			: base(logger,
			       transactionCoordinator,
			       businessEntityContactRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>34d3142d81586f299c054c6c35d0c94b</Hash>
</Codenesium>*/