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
	[ServiceFilter(typeof(VendorFilter))]
	public class VendorController: AbstractVendorController
	{
		public VendorController(
			ILogger<VendorController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVendorRepository vendorRepository
			)
			: base(logger,
			       transactionCoordinator,
			       vendorRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2926d63cf4ff4a65520e845290efb34e</Hash>
</Codenesium>*/