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
			ApplicationContext context,
			ISpecialOfferProductRepository specialOfferProductRepository,
			ISpecialOfferProductModelValidator specialOfferProductModelValidator
			) : base(logger,
			         context,
			         specialOfferProductRepository,
			         specialOfferProductModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>df280400b0a3913989e9da5bb33ae9b7</Hash>
</Codenesium>*/