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
	[Route("api/businessEntityContacts")]
	[ApiVersion("1.0")]
	public class BusinessEntityContactController: AbstractBusinessEntityContactController
	{
		public BusinessEntityContactController(
			ILogger<BusinessEntityContactController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOBusinessEntityContact businessEntityContactManager
			)
			: base(logger,
			       transactionCoordinator,
			       businessEntityContactManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>dd5b57423b3cb37a7be7a11534ade10d</Hash>
</Codenesium>*/