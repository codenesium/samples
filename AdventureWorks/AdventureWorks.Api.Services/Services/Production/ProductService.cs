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
	public class ProductService: AbstractProductService, IProductService
	{
		public ProductService(
			ILogger<ProductRepository> logger,
			IProductRepository productRepository,
			IApiProductRequestModelValidator productModelValidator,
			IBOLProductMapper BOLproductMapper,
			IDALProductMapper DALproductMapper)
			: base(logger, productRepository,
			       productModelValidator,
			       BOLproductMapper,
			       DALproductMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>b7b469ed71ddf4ccb0da02d1e735e3db</Hash>
</Codenesium>*/