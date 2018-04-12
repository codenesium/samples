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
	[Route("api/personPhones")]
	public class PersonPhoneController: AbstractPersonPhoneController
	{
		public PersonPhoneController(
			ILogger<PersonPhoneController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonPhoneRepository personPhoneRepository,
			IPersonPhoneModelValidator personPhoneModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       personPhoneRepository,
			       personPhoneModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>bf9d58be2fef75371455c5f9903f129c</Hash>
</Codenesium>*/