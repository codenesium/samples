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
	[Route("api/businessEntityContacts")]
	public class BusinessEntityContactsController: AbstractBusinessEntityContactsController
	{
		public BusinessEntityContactsController(
			ILogger<BusinessEntityContactsController> logger,
			ApplicationContext context,
			IBusinessEntityContactRepository businessEntityContactRepository,
			IBusinessEntityContactModelValidator businessEntityContactModelValidator
			) : base(logger,
			         context,
			         businessEntityContactRepository,
			         businessEntityContactModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>350fb4d8aaa47006b1d41d72c36d333a</Hash>
</Codenesium>*/