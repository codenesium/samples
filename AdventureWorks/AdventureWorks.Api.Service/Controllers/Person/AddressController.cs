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
	public class AddressesController: AbstractAddressesController
	{
		public AddressesController(
			ILogger<AddressesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAddressRepository addressRepository,
			IAddressModelValidator addressModelValidator
			) : base(logger,
			         transactionCoordinator,
			         addressRepository,
			         addressModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8b615aab014396bf2b475458204b1760</Hash>
</Codenesium>*/