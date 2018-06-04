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
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/businessEntityContacts")]
	[ApiVersion("1.0")]
	public class BusinessEntityContactController: AbstractBusinessEntityContactController
	{
		public BusinessEntityContactController(
			ServiceSettings settings,
			ILogger<BusinessEntityContactController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBusinessEntityContactService businessEntityContactService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       businessEntityContactService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>31754d081e3219e9d3eeb84b82215acd</Hash>
</Codenesium>*/