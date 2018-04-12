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
	public class SpecialOfferController: AbstractSpecialOfferController
	{
		public SpecialOfferController(
			ILogger<SpecialOfferController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpecialOfferRepository specialOfferRepository,
			ISpecialOfferModelValidator specialOfferModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       specialOfferRepository,
			       specialOfferModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7154f4adfb2c7bf9ecc3d1427e666945</Hash>
</Codenesium>*/