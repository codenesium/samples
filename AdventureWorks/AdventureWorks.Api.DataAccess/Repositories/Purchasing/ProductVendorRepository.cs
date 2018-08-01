using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class ProductVendorRepository : AbstractProductVendorRepository, IProductVendorRepository
	{
		public ProductVendorRepository(
			ILogger<ProductVendorRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f7c9f6d2b1719cb7ef71f8b5daadbf5b</Hash>
</Codenesium>*/