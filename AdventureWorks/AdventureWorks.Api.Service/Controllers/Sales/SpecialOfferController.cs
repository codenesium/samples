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
	[Route("api/specialOffers")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(SpecialOfferFilter))]
	public class SpecialOfferController: AbstractSpecialOfferController
	{
		public SpecialOfferController(
			ILogger<SpecialOfferController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpecialOfferRepository specialOfferRepository
			)
			: base(logger,
			       transactionCoordinator,
			       specialOfferRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1a92b56435acf6c2f0c749f1d3483f38</Hash>
</Codenesium>*/