using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/addresses")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(AddressFilter))]
	public class AddressController: AbstractAddressController
	{
		public AddressController(
			ILogger<AddressController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAddressRepository addressRepository
			)
			: base(logger,
			       transactionCoordinator,
			       addressRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>51fa51b55ef12446e0d218c4b4d0ba03</Hash>
</Codenesium>*/