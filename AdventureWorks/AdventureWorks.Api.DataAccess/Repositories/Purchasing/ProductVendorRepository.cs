using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ProductVendorRepository: AbstractProductVendorRepository, IProductVendorRepository
	{
		public ProductVendorRepository(
			IDALProductVendorMapper mapper,
			ILogger<ProductVendorRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>248917b8ad8d9be636b6bd5123a72f71</Hash>
</Codenesium>*/