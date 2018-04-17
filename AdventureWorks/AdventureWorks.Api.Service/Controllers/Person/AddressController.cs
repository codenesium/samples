using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/addresses")]
	[ApiVersion("1.0")]
	public class AddressController: AbstractAddressController
	{
		public AddressController(
			ILogger<AddressController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOAddress addressManager
			)
			: base(logger,
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
    <Hash>b94eb3e3bc930397c600cb7b6892689a</Hash>
</Codenesium>*/