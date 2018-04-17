using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/specialOffers")]
	[ApiVersion("1.0")]
	public class SpecialOfferController: AbstractSpecialOfferController
	{
		public SpecialOfferController(
			ILogger<SpecialOfferController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSpecialOffer specialOfferManager
			)
			: base(logger,
			       transactionCoordinator,
			       specialOfferManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b3da7dad2a03601dd0b0ca2d4c1eb05b</Hash>
</Codenesium>*/