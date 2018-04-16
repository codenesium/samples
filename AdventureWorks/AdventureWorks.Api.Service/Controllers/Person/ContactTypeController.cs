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
	[Route("api/contactTypes")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(ContactTypeFilter))]
	public class ContactTypeController: AbstractContactTypeController
	{
		public ContactTypeController(
			ILogger<ContactTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IContactTypeRepository contactTypeRepository
			)
			: base(logger,
			       transactionCoordinator,
			       contactTypeRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9846971591f3a57aca23640f3e2b4d1c</Hash>
</Codenesium>*/