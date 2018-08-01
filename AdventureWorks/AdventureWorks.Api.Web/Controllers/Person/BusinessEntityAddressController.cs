using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/businessEntityAddresses")]
	[ApiController]
	[ApiVersion("1.0")]
	public class BusinessEntityAddressController : AbstractBusinessEntityAddressController
	{
		public BusinessEntityAddressController(
			ApiSettings settings,
			ILogger<BusinessEntityAddressController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBusinessEntityAddressService businessEntityAddressService,
			IApiBusinessEntityAddressModelMapper businessEntityAddressModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       businessEntityAddressService,
			       businessEntityAddressModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7dfe6fdd2237303090b87c02c0016c9f</Hash>
</Codenesium>*/