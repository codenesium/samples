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
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/specialOffers")]
	[ApiVersion("1.0")]
	[Response]
	public class SpecialOfferController: AbstractSpecialOfferController
	{
		public SpecialOfferController(
			ServiceSettings settings,
			ILogger<SpecialOfferController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSpecialOffer specialOfferManager
			)
			: base(settings,
			       logger,
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
    <Hash>1600e7af2e1a2c341b08ee90c3739651</Hash>
</Codenesium>*/