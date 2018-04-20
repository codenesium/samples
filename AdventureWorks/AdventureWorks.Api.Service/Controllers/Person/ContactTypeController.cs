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
	[Route("api/contactTypes")]
	[ApiVersion("1.0")]
	[Response]
	public class ContactTypeController: AbstractContactTypeController
	{
		public ContactTypeController(
			ServiceSettings settings,
			ILogger<ContactTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOContactType contactTypeManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       contactTypeManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>186c81a250b47efa3276f7fce2aa4a95</Hash>
</Codenesium>*/