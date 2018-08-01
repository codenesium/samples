using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/businessEntities")]
	[ApiController]
	[ApiVersion("1.0")]
	public class BusinessEntityController : AbstractBusinessEntityController
	{
		public BusinessEntityController(
			ApiSettings settings,
			ILogger<BusinessEntityController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBusinessEntityService businessEntityService,
			IApiBusinessEntityModelMapper businessEntityModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       businessEntityService,
			       businessEntityModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a6e508888fa5e75c854d592642e2cc8c</Hash>
</Codenesium>*/