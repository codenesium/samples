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
	[Route("api/personPhones")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(PersonPhoneFilter))]
	public class PersonPhoneController: AbstractPersonPhoneController
	{
		public PersonPhoneController(
			ILogger<PersonPhoneController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonPhoneRepository personPhoneRepository
			)
			: base(logger,
			       transactionCoordinator,
			       personPhoneRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>99df2815beaeeebb3b79db866dee4685</Hash>
</Codenesium>*/