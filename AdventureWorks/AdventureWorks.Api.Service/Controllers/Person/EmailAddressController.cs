using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/emailAddresses")]
	public class EmailAddressController: AbstractEmailAddressController
	{
		public EmailAddressController(
			ILogger<EmailAddressController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmailAddressRepository emailAddressRepository,
			IEmailAddressModelValidator emailAddressModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       emailAddressRepository,
			       emailAddressModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b6c662cbe2961ea0de1edde33d58ea8f</Hash>
</Codenesium>*/