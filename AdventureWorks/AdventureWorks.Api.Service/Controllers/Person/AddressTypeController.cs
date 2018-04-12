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
	[Route("api/addressTypes")]
	public class AddressTypeController: AbstractAddressTypeController
	{
		public AddressTypeController(
			ILogger<AddressTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAddressTypeRepository addressTypeRepository,
			IAddressTypeModelValidator addressTypeModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       addressTypeRepository,
			       addressTypeModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>69c39ca72fd462e6565c532a029cac37</Hash>
</Codenesium>*/