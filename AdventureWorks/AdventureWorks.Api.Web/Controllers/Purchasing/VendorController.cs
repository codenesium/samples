using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/vendors")]
	[ApiController]
	[ApiVersion("1.0")]
	public class VendorController : AbstractVendorController
	{
		public VendorController(
			ApiSettings settings,
			ILogger<VendorController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVendorService vendorService,
			IApiVendorModelMapper vendorModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       vendorService,
			       vendorModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4f2cda146239abd9674e0983b2128b5c</Hash>
</Codenesium>*/