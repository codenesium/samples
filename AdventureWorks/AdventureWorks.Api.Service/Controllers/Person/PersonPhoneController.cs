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
	public class PersonPhonesController: AbstractPersonPhonesController
	{
		public PersonPhonesController(
			ILogger<PersonPhonesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonPhoneRepository personPhoneRepository,
			IPersonPhoneModelValidator personPhoneModelValidator
			) : base(logger,
			         transactionCoordinator,
			         personPhoneRepository,
			         personPhoneModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>fc7862110c2db41af161586ed1eca7e5</Hash>
</Codenesium>*/