using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/emailAddresses")]
	[ApiVersion("1.0")]
	public class EmailAddressController: AbstractEmailAddressController
	{
		public EmailAddressController(
			ILogger<EmailAddressController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOEmailAddress emailAddressManager
			)
			: base(logger,
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
    <Hash>c6890efc6caae50c3abe44db09276e60</Hash>
</Codenesium>*/