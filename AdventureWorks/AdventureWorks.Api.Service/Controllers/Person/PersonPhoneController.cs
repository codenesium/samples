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
	[Route("api/personPhones")]
	[ApiVersion("1.0")]
	public class PersonPhoneController: AbstractPersonPhoneController
	{
		public PersonPhoneController(
			ILogger<PersonPhoneController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPersonPhone personPhoneManager
			)
			: base(logger,
			       transactionCoordinator,
			       personPhoneManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6c9e116dd49c32d5105636f69a7969a8</Hash>
</Codenesium>*/