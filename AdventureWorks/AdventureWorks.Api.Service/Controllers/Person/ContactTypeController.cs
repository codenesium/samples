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
	[Route("api/contactTypes")]
	[ApiVersion("1.0")]
	public class ContactTypeController: AbstractContactTypeController
	{
		public ContactTypeController(
			ILogger<ContactTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOContactType contactTypeManager
			)
			: base(logger,
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
    <Hash>f464dc126787cf2ecb25e31cccba00bb</Hash>
</Codenesium>*/