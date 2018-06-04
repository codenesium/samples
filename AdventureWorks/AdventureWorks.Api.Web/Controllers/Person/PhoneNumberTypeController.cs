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
	[Route("api/phoneNumberTypes")]
	[ApiVersion("1.0")]
	public class PhoneNumberTypeController: AbstractPhoneNumberTypeController
	{
		public PhoneNumberTypeController(
			ServiceSettings settings,
			ILogger<PhoneNumberTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPhoneNumberTypeService phoneNumberTypeService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       phoneNumberTypeService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8a6a69f42087a204a22bb0d7e6599d13</Hash>
</Codenesium>*/