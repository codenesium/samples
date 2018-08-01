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
	[Route("api/phoneNumberTypes")]
	[ApiController]
	[ApiVersion("1.0")]
	public class PhoneNumberTypeController : AbstractPhoneNumberTypeController
	{
		public PhoneNumberTypeController(
			ApiSettings settings,
			ILogger<PhoneNumberTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPhoneNumberTypeService phoneNumberTypeService,
			IApiPhoneNumberTypeModelMapper phoneNumberTypeModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       phoneNumberTypeService,
			       phoneNumberTypeModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>13ebd15a6393ff0219f4b8eec0eab5f4</Hash>
</Codenesium>*/