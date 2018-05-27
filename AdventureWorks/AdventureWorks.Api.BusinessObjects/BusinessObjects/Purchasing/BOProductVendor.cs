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
	public class BOProductVendor: AbstractBOProductVendor, IBOProductVendor
	{
		public BOProductVendor(
			ILogger<ProductVendorRepository> logger,
			IProductVendorRepository productVendorRepository,
			IApiProductVendorRequestModelValidator productVendorModelValidator,
			IBOLProductVendorMapper productVendorMapper)
			: base(logger, productVendorRepository, productVendorModelValidator, productVendorMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>8f8860723acaccf0af781fc38050a01e</Hash>
</Codenesium>*/