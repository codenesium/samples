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
	[Route("api/addressTypes")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(AddressTypeFilter))]
	public class AddressTypeController: AbstractAddressTypeController
	{
		public AddressTypeController(
			ILogger<AddressTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAddressTypeRepository addressTypeRepository
			)
			: base(logger,
			       transactionCoordinator,
			       addressTypeRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>567d2cc31ef0b345a9f6c8d25e0da35f</Hash>
</Codenesium>*/