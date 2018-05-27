using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOVendor: AbstractBOVendor, IBOVendor
	{
		public BOVendor(
			ILogger<VendorRepository> logger,
			IVendorRepository vendorRepository,
			IApiVendorRequestModelValidator vendorModelValidator,
			IBOLVendorMapper vendorMapper)
			: base(logger, vendorRepository, vendorModelValidator, vendorMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>4b09fd553fda1844a8be30be33111b08</Hash>
</Codenesium>*/