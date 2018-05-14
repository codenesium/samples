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
    <Hash>fc0568bbf0a318a94965613ac3d3ef08</Hash>
</Codenesium>*/