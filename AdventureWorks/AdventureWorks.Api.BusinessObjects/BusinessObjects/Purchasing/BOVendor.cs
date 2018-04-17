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
			IVendorModelValidator vendorModelValidator)
			: base(logger, vendorRepository, vendorModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>45f65afdbd75758ebe83384514ee404d</Hash>
</Codenesium>*/