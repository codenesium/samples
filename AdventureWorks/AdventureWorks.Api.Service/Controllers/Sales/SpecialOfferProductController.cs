using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/specialOfferProducts")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(SpecialOfferProductFilter))]
	public class SpecialOfferProductController: AbstractSpecialOfferProductController
	{
		public SpecialOfferProductController(
			ILogger<SpecialOfferProductController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpecialOfferProductRepository specialOfferProductRepository
			)
			: base(logger,
			       transactionCoordinator,
			       specialOfferProductRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>cc29d7d2659f234a11b227441200dd37</Hash>
</Codenesium>*/