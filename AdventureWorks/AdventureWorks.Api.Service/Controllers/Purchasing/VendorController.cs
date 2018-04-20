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
	[Route("api/vendors")]
	[ApiVersion("1.0")]
	[Response]
	public class VendorController: AbstractVendorController
	{
		public VendorController(
			ServiceSettings settings,
			ILogger<VendorController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOVendor vendorManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       vendorManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>430feed20f4c6315b5585f151a8d4b68</Hash>
</Codenesium>*/