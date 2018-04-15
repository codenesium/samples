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
	[Route("api/vendors")]
	[ApiVersion("1.0")]
	public class VendorController: AbstractVendorController
	{
		public VendorController(
			ILogger<VendorController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVendorRepository vendorRepository,
			IVendorModelValidator vendorModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       vendorRepository,
			       vendorModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e923d9884998619763d0a4893f6a389e</Hash>
</Codenesium>*/