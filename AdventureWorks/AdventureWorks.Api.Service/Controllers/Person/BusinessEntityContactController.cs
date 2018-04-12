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
	[Route("api/businessEntityContacts")]
	public class BusinessEntityContactController: AbstractBusinessEntityContactController
	{
		public BusinessEntityContactController(
			ILogger<BusinessEntityContactController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBusinessEntityContactRepository businessEntityContactRepository,
			IBusinessEntityContactModelValidator businessEntityContactModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       businessEntityContactRepository,
			       businessEntityContactModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d86aea52b862c4450b0d16dd30b4baec</Hash>
</Codenesium>*/