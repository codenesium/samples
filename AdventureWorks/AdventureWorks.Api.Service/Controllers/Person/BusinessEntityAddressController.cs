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
	[Route("api/businessEntityAddresses")]
	[ApiVersion("1.0")]
	public class BusinessEntityAddressController: AbstractBusinessEntityAddressController
	{
		public BusinessEntityAddressController(
			ILogger<BusinessEntityAddressController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOBusinessEntityAddress businessEntityAddressManager
			)
			: base(logger,
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
    <Hash>30c2feabfd01dbbfa26d3332a96badd8</Hash>
</Codenesium>*/