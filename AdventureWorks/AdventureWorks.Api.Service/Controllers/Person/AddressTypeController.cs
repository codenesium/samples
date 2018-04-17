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
	[Route("api/addressTypes")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class AddressTypeController: AbstractAddressTypeController
	{
		public AddressTypeController(
			ILogger<AddressTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOAddressType addressTypeManager
			)
			: base(logger,
			       transactionCoordinator,
			       addressTypeManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>109a0e15a31a82b568e849f0bde24fa6</Hash>
</Codenesium>*/