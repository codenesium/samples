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
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/emailAddresses")]
	[ApiVersion("1.0")]
	[Response]
	public class EmailAddressController: AbstractEmailAddressController
	{
		public EmailAddressController(
			ServiceSettings settings,
			ILogger<EmailAddressController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOEmailAddress emailAddressManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       emailAddressManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>fbf8a03a416336fdd6d84365c7ffa09e</Hash>
</Codenesium>*/