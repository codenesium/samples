using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ProductVendorService: AbstractProductVendorService, IProductVendorService
	{
		public ProductVendorService(
			ILogger<ProductVendorRepository> logger,
			IProductVendorRepository productVendorRepository,
			IApiProductVendorRequestModelValidator productVendorModelValidator,
			IBOLProductVendorMapper BOLproductVendorMapper,
			IDALProductVendorMapper DALproductVendorMapper)
			: base(logger, productVendorRepository,
			       productVendorModelValidator,
			       BOLproductVendorMapper,
			       DALproductVendorMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>a3d3e823467bbe1447e9aabb14ab8db0</Hash>
</Codenesium>*/