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
	[ResponseFilter]
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
    <Hash>19978725cd196eee57b3b1628a2a428b</Hash>
</Codenesium>*/