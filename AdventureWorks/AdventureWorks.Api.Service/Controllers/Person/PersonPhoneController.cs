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
	[Route("api/personPhones")]
	[ApiVersion("1.0")]
	[Response]
	public class PersonPhoneController: AbstractPersonPhoneController
	{
		public PersonPhoneController(
			ServiceSettings settings,
			ILogger<PersonPhoneController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPersonPhone personPhoneManager
			)
			: base(settings,
			       logger,
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
    <Hash>a0b8eed692f2a53769f0b8cbfc32d628</Hash>
</Codenesium>*/