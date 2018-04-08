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
	[Route("api/specialOffers")]
	public class SpecialOffersController: AbstractSpecialOffersController
	{
		public SpecialOffersController(
			ILogger<SpecialOffersController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpecialOfferRepository specialOfferRepository,
			ISpecialOfferModelValidator specialOfferModelValidator
			) : base(logger,
			         transactionCoordinator,
			         specialOfferRepository,
			         specialOfferModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c6041dcf053abd19291f555cafd80a70</Hash>
</Codenesium>*/