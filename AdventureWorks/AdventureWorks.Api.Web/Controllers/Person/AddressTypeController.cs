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
	[Route("api/addressTypes")]
	[ApiVersion("1.0")]
	public class AddressTypeController: AbstractAddressTypeController
	{
		public AddressTypeController(
			ServiceSettings settings,
			ILogger<AddressTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAddressTypeService addressTypeService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       addressTypeService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>cda2fdb60f099fd6c7df49069f8141ff</Hash>
</Codenesium>*/