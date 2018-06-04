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
	[Route("api/addresses")]
	[ApiVersion("1.0")]
	public class AddressController: AbstractAddressController
	{
		public AddressController(
			ServiceSettings settings,
			ILogger<AddressController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAddressService addressService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       addressService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0fb77dfe89049f23b3ea9259a51a1784</Hash>
</Codenesium>*/