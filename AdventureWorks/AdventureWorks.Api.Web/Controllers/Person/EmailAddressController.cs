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
	[Route("api/emailAddresses")]
	[ApiVersion("1.0")]
	public class EmailAddressController: AbstractEmailAddressController
	{
		public EmailAddressController(
			ServiceSettings settings,
			ILogger<EmailAddressController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmailAddressService emailAddressService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       emailAddressService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>33eb0974566ac47d4e55e68ba3c703a0</Hash>
</Codenesium>*/