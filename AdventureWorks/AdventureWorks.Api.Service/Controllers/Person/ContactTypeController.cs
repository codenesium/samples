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
	[Route("api/contactTypes")]
	public class ContactTypesController: AbstractContactTypesController
	{
		public ContactTypesController(
			ILogger<ContactTypesController> logger,
			ApplicationContext context,
			IContactTypeRepository contactTypeRepository,
			IContactTypeModelValidator contactTypeModelValidator
			) : base(logger,
			         context,
			         contactTypeRepository,
			         contactTypeModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>bf05805b0f47ef88522891bf8336f4a1</Hash>
</Codenesium>*/