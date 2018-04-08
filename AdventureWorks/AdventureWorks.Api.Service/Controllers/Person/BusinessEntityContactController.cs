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
			ITransactionCoordinator transactionCoordinator,
			IBusinessEntityContactRepository businessEntityContactRepository,
			IBusinessEntityContactModelValidator businessEntityContactModelValidator
			) : base(logger,
			         transactionCoordinator,
			         businessEntityContactRepository,
			         businessEntityContactModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>75fcc3d5322302f63be3f7d6e13a0df6</Hash>
</Codenesium>*/