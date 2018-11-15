using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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
	[Authorize(Policy = "DefaultAccess")]

	public class VendorController : AbstractVendorController
	{
		public VendorController(
			ApiSettings settings,
			ILogger<VendorController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVendorService vendorService,
			IApiVendorServerModelMapper vendorModelMapper
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
    <Hash>d4e95202e7b9b3604a956dfbcfceafc8</Hash>
</Codenesium>*/