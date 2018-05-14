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
	[Route("api/addresses")]
	[ApiVersion("1.0")]
	public class AddressController: AbstractAddressController
	{
		public AddressController(
			ServiceSettings settings,
			ILogger<AddressController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOAddress addressManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       addressManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b3b9b5213c414706beccac1fafaa86eb</Hash>
</Codenesium>*/