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
	[Route("api/businessEntityContacts")]
	[ApiVersion("1.0")]
	[Response]
	public class BusinessEntityContactController: AbstractBusinessEntityContactController
	{
		public BusinessEntityContactController(
			ServiceSettings settings,
			ILogger<BusinessEntityContactController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOBusinessEntityContact businessEntityContactManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       businessEntityContactManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8172f4cb40f09ab15e0654c181e9a4f7</Hash>
</Codenesium>*/