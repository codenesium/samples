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
	[Route("api/addressTypes")]
	[ApiVersion("1.0")]
	[Response]
	public class AddressTypeController: AbstractAddressTypeController
	{
		public AddressTypeController(
			ServiceSettings settings,
			ILogger<AddressTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOAddressType addressTypeManager
			)
			: base(settings,
			       logger,
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
    <Hash>fb43601123d21131aca68095a076e572</Hash>
</Codenesium>*/