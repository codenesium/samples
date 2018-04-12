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
	public class SpecialOfferProductController: AbstractSpecialOfferProductController
	{
		public SpecialOfferProductController(
			ILogger<SpecialOfferProductController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpecialOfferProductRepository specialOfferProductRepository,
			ISpecialOfferProductModelValidator specialOfferProductModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       specialOfferProductRepository,
			       specialOfferProductModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>940bedff1a8cb6bee6dd775012f7246e</Hash>
</Codenesium>*/