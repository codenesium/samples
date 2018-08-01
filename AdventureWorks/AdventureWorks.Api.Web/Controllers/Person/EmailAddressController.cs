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
	[Route("api/emailAddresses")]
	[ApiController]
	[ApiVersion("1.0")]
	public class EmailAddressController : AbstractEmailAddressController
	{
		public EmailAddressController(
			ApiSettings settings,
			ILogger<EmailAddressController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmailAddressService emailAddressService,
			IApiEmailAddressModelMapper emailAddressModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       emailAddressService,
			       emailAddressModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>aafcefb3d953a686266a01677e2d1b56</Hash>
</Codenesium>*/