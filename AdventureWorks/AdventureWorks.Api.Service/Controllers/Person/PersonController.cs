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
	[Route("api/people")]
	public class PeopleController: AbstractPeopleController
	{
		public PeopleController(
			ILogger<PeopleController> logger,
			ApplicationContext context,
			IPersonRepository personRepository,
			IPersonModelValidator personModelValidator
			) : base(logger,
			         context,
			         personRepository,
			         personModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>bb0a6a1f20ac56ef5686f18f5f639978</Hash>
</Codenesium>*/