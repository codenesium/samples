using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/emailAddresses")]
	[ApiVersion("1.0")]
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
    <Hash>7f78162e4881d5694f540a7b9a33e56f</Hash>
</Codenesium>*/