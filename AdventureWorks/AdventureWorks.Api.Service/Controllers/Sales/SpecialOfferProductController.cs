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
	[Route("api/specialOfferProducts")]
	[ApiVersion("1.0")]
	public class SpecialOfferProductController: AbstractSpecialOfferProductController
	{
		public SpecialOfferProductController(
			ServiceSettings settings,
			ILogger<SpecialOfferProductController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSpecialOfferProduct specialOfferProductManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       specialOfferProductManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>daa9e6ca254091fd6e96af59910fbb97</Hash>
</Codenesium>*/