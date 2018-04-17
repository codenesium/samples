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
    <Hash>956ae8a35bbc68aa14b27b06e6c2b747</Hash>
</Codenesium>*/