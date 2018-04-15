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
	public class AddressController: AbstractAddressController
	{
		public AddressController(
			ILogger<AddressController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAddressRepository addressRepository,
			IAddressModelValidator addressModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       addressRepository,
			       addressModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e6c5867c840e7bc822c5082f5193a2df</Hash>
</Codenesium>*/