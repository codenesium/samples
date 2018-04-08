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
	public class VendorsController: AbstractVendorsController
	{
		public VendorsController(
			ILogger<VendorsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVendorRepository vendorRepository,
			IVendorModelValidator vendorModelValidator
			) : base(logger,
			         transactionCoordinator,
			         vendorRepository,
			         vendorModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c3ea7306eb11180525a11a27dfba6f12</Hash>
</Codenesium>*/