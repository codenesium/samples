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
			ApplicationContext context,
			ISpecialOfferRepository specialOfferRepository,
			ISpecialOfferModelValidator specialOfferModelValidator
			) : base(logger,
			         context,
			         specialOfferRepository,
			         specialOfferModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>dc6e647237bbd140213510a128653d44</Hash>
</Codenesium>*/