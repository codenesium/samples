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
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/addresses")]
	[ApiController]
	[ApiVersion("1.0")]
	public class AddressController : AbstractAddressController
	{
		public AddressController(
			ApiSettings settings,
			ILogger<AddressController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAddressService addressService,
			IApiAddressModelMapper addressModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       addressService,
			       addressModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2b95a41ce6d26e0152cd791966c2fa05</Hash>
</Codenesium>*/