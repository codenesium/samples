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
	[Route("api/specialOfferProducts")]
	public class SpecialOfferProductsController: AbstractSpecialOfferProductsController
	{
		public SpecialOfferProductsController(
			ILogger<SpecialOfferProductsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpecialOfferProductRepository specialOfferProductRepository,
			ISpecialOfferProductModelValidator specialOfferProductModelValidator
			) : base(logger,
			         transactionCoordinator,
			         specialOfferProductRepository,
			         specialOfferProductModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ec71e046f85545a98e30bf9cb5218126</Hash>
</Codenesium>*/