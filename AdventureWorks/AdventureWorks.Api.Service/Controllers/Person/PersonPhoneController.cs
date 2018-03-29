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
			ApplicationContext context,
			IPersonPhoneRepository personPhoneRepository,
			IPersonPhoneModelValidator personPhoneModelValidator
			) : base(logger,
			         context,
			         personPhoneRepository,
			         personPhoneModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>87fb639d8e22d57e9d48a728c2ae8afd</Hash>
</Codenesium>*/