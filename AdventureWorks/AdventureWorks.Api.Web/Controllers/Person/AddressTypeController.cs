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
	[Route("api/addressTypes")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class AddressTypeController : AbstractAddressTypeController
	{
		public AddressTypeController(
			ApiSettings settings,
			ILogger<AddressTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAddressTypeService addressTypeService,
			IApiAddressTypeServerModelMapper addressTypeModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       addressTypeService,
			       addressTypeModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>475beb1cd4673091b3afe10c35661368</Hash>
</Codenesium>*/