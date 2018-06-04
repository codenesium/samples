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
	public class ProductCategoryService: AbstractProductCategoryService, IProductCategoryService
	{
		public ProductCategoryService(
			ILogger<ProductCategoryRepository> logger,
			IProductCategoryRepository productCategoryRepository,
			IApiProductCategoryRequestModelValidator productCategoryModelValidator,
			IBOLProductCategoryMapper BOLproductCategoryMapper,
			IDALProductCategoryMapper DALproductCategoryMapper)
			: base(logger, productCategoryRepository,
			       productCategoryModelValidator,
			       BOLproductCategoryMapper,
			       DALproductCategoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>f3ce867bbdabce3e9ffd574e67653de7</Hash>
</Codenesium>*/