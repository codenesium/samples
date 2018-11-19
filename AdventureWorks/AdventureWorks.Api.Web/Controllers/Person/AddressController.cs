using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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
			IApiAddressServerModelMapper addressModelMapper
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
    <Hash>b2cb03fb74e0b72243f53ac9f736f012</Hash>
</Codenesium>*/