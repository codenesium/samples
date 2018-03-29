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
			ApplicationContext context,
			IVendorRepository vendorRepository,
			IVendorModelValidator vendorModelValidator
			) : base(logger,
			         context,
			         vendorRepository,
			         vendorModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4c451ca887e0868cd1310bc73c9870b6</Hash>
</Codenesium>*/