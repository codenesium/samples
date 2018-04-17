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
	[Route("api/vendors")]
	[ApiVersion("1.0")]
	public class VendorController: AbstractVendorController
	{
		public VendorController(
			ILogger<VendorController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOVendor vendorManager
			)
			: base(logger,
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
    <Hash>f833c9bee4060c431568e6e5778f1835</Hash>
</Codenesium>*/