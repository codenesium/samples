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
	[Route("api/vendors")]
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
    <Hash>b87c82794a74c2de4253711b2f2a3870</Hash>
</Codenesium>*/