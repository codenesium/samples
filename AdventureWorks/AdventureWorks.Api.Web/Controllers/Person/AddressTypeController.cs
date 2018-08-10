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
	[Route("api/addressTypes")]
	[ApiController]
	[ApiVersion("1.0")]
	public class AddressTypeController : AbstractAddressTypeController
	{
		public AddressTypeController(
			ApiSettings settings,
			ILogger<AddressTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAddressTypeService addressTypeService,
			IApiAddressTypeModelMapper addressTypeModelMapper
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
    <Hash>d81f604b7af7abe2a0ec9bdd50813984</Hash>
</Codenesium>*/