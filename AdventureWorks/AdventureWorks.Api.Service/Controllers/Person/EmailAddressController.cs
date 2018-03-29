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
			ApplicationContext context,
			IEmailAddressRepository emailAddressRepository,
			IEmailAddressModelValidator emailAddressModelValidator
			) : base(logger,
			         context,
			         emailAddressRepository,
			         emailAddressModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2b65a110fb767c220689132299aab29c</Hash>
</Codenesium>*/