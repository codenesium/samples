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
	[Route("api/businessEntityAddresses")]
	[ApiVersion("1.0")]
	public class BusinessEntityAddressController: AbstractBusinessEntityAddressController
	{
		public BusinessEntityAddressController(
			ServiceSettings settings,
			ILogger<BusinessEntityAddressController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOBusinessEntityAddress businessEntityAddressManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       businessEntityAddressManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>08c920d9dcc1bc4f6d2d97845c92f626</Hash>
</Codenesium>*/