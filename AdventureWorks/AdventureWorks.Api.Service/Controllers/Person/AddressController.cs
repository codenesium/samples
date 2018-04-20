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
	[Response]
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
    <Hash>0c3e64096a1fb0f4010158f2ba4a4a72</Hash>
</Codenesium>*/