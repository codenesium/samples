using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class ProductCategoryService : AbstractProductCategoryService, IProductCategoryService
	{
		public ProductCategoryService(
			ILogger<IProductCategoryRepository> logger,
			IProductCategoryRepository productCategoryRepository,
			IApiProductCategoryRequestModelValidator productCategoryModelValidator,
			IBOLProductCategoryMapper bolproductCategoryMapper,
			IDALProductCategoryMapper dalproductCategoryMapper,
			IBOLProductSubcategoryMapper bolProductSubcategoryMapper,
			IDALProductSubcategoryMapper dalProductSubcategoryMapper
			)
			: base(logger,
			       productCategoryRepository,
			       productCategoryModelValidator,
			       bolproductCategoryMapper,
			       dalproductCategoryMapper,
			       bolProductSubcategoryMapper,
			       dalProductSubcategoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>79976cd17d32f480d417f162192dd4a9</Hash>
</Codenesium>*/