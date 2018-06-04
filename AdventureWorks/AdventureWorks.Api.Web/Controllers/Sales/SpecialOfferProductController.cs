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
	[Route("api/specialOfferProducts")]
	[ApiVersion("1.0")]
	public class SpecialOfferProductController: AbstractSpecialOfferProductController
	{
		public SpecialOfferProductController(
			ServiceSettings settings,
			ILogger<SpecialOfferProductController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpecialOfferProductService specialOfferProductService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       specialOfferProductService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a2b1da9d3e93f3bec333c6e96f5f69ee</Hash>
</Codenesium>*/