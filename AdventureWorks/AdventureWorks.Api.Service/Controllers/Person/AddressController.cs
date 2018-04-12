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
	[Route("api/addresses")]
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
    <Hash>317a73d515686fdbae01174202166c3f</Hash>
</Codenesium>*/