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
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/businessEntityAddresses")]
	[ApiVersion("1.0")]
	public class BusinessEntityAddressController: AbstractBusinessEntityAddressController
	{
		public BusinessEntityAddressController(
			ServiceSettings settings,
			ILogger<BusinessEntityAddressController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBusinessEntityAddressService businessEntityAddressService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       businessEntityAddressService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e6fe7f5498416a44abeb223b3abd2c96</Hash>
</Codenesium>*/