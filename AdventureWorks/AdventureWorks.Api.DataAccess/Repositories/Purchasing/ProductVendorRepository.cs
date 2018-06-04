using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ProductVendorRepository: AbstractProductVendorRepository, IProductVendorRepository
	{
		public ProductVendorRepository(
			ILogger<ProductVendorRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>344403daa4e9a17a70690786055686f6</Hash>
</Codenesium>*/