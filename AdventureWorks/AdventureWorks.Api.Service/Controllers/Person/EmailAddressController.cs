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
	public class EmailAddressesController: AbstractEmailAddressesController
	{
		public EmailAddressesController(
			ILogger<EmailAddressesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmailAddressRepository emailAddressRepository,
			IEmailAddressModelValidator emailAddressModelValidator
			) : base(logger,
			         transactionCoordinator,
			         emailAddressRepository,
			         emailAddressModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>3a2e5bf032fd49ec7bcb1782e28ecede</Hash>
</Codenesium>*/